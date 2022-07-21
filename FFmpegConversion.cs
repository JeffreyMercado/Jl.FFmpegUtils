using System.Diagnostics;
using System.Text;

namespace Jl.FFmpegUtils;

public record FFmpegConversion(IFFmpegClArguments Arguments) : IFFmpegConversion
{
    public event EventHandler<ConversionData>? DataReceived;
    public event EventHandler<ConversionProgress>? ProgressReceived;

    public async Task<IFFmpegConversionResult> ConvertAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default)
    {
        var arguments = Arguments.SerializeArguments();
        var observer = new DataObserver(this, DateTime.Now, cancellationToken);
        var observerTask = observer.Task;
        var convertTask = provider.ConvertAsync(arguments, observer, cancellationToken);
        await Task.WhenAll(observerTask, convertTask).ConfigureAwait(false);
        var result = convertTask.Result;
        return new FFmpegConversionResult(Arguments, result.StartTime, result.EndTime);
    }
    private void OnDataReceived(ConversionData e)
    {
        DataReceived?.Invoke(this, e);
    }
    private void OnProgressReceived(ConversionProgress e)
    {
        ProgressReceived?.Invoke(this, e);
    }

    private record FFmpegConversionResult(IFFmpegClArguments Arguments, DateTime StartTime, DateTime EndTime) : IFFmpegConversionResult
    {
        public IEnumerable<IFFmpegOutputSink> Outputs => Arguments.Outputs.Select(x => x.Sink);
        public TimeSpan Duration => EndTime - StartTime;
        public bool IsFinished => true;
    }

    private class DataObserver : IObserver<DataReceivedEventArgs>
    {
        private readonly TaskCompletionSource tcs = new TaskCompletionSource();
        private readonly StringBuilder buffer = new StringBuilder();
        private readonly FFmpegConversion conversion;
        private readonly DateTime startTime;
        private readonly long? size;
        private readonly TimeSpan? duration;
        public DataObserver(FFmpegConversion conversion, DateTime startTime, CancellationToken cancellationToken)
        {
            this.conversion = conversion;
            this.startTime = startTime;
            var inputs = conversion.Arguments.Inputs;
            (duration, size) = inputs.Count == 1 && inputs.Single() is IFFmpegInput input
                ? (input.Duration, input.Size)
                : (EstimateDuration(inputs), default);
            cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));

            static TimeSpan EstimateDuration(IReadOnlyList<IFFmpegInput> inputs)
            {
                try
                {
                    var inputLength = inputs.Aggregate(default(TimeSpan), (a, x) =>
                        a + GetInputLength(x)
                    );
                    var silenceLength = inputs.Aggregate(default(TimeSpan), (a, x) => a + GetSilenceLength(x));
                    return inputLength + silenceLength;
                }
                catch
                {
                    return inputs.Aggregate(default(TimeSpan), (a, x) => a + x.Duration);
                }
            }
            static TimeSpan GetInputLength(IFFmpegInput input)
            {
                var duration = input.Duration;
                var streamSeek = input.Arguments.OfType<Arguments.InputOutputStreamSeekArgument>().SingleOrDefault()?.Value ?? TimeSpan.Zero;
                var timeDuration = input.Arguments.OfType<Arguments.InputOutputTimeDurationArgument>().SingleOrDefault()?.Value;
                var timeTo = input.Arguments.OfType<Arguments.InputOutputTimeToArgument>().SingleOrDefault()?.Value;
                return (timeDuration, timeTo) switch
                {
                    ({} t, _) => t,
                    (null, {} tt) => tt - streamSeek,
                    _ => duration - streamSeek,
                };
            }
            static TimeSpan GetSilenceLength(IFFmpegInput input) => input.Arguments
                .OfType<Arguments.InputTimeOffsetArgument>()
                .Select(x => x.Value)
                .SingleOrDefault();
        }

        public Task Task => tcs.Task;
        public bool IsFinished { get; private set; }

        public void OnNext(DataReceivedEventArgs value)
        {
            if (value.Data is string data)
            {
                if (ConversionProgress.TryParse(data, size, duration) is ConversionProgress progress)
                {
                    conversion.OnProgressReceived(progress);
                    if (progress.IsLast)
                        IsFinished = true;
                }
                else
                {
                    buffer.AppendLine(data);
                    conversion.OnDataReceived(new ConversionData(data));
                }
            }
        }

        public void OnError(Exception error)
        {
            // suppress cancellations here, let main thread handle that
            if (error is not OperationCanceledException)
            {
                // FFmpeg errors aren't clearly reported, output the prefiltered buffer for the message
                var exception = new FFmpegConversionException(
                    "Conversion failed",
                    buffer.ToString(),
                    conversion.Arguments,
                    startTime,
                    DateTime.Now,
                    IsFinished
                );
                tcs.TrySetException(exception);
            }
        }

        public void OnCompleted()
        {
            tcs.TrySetResult();
        }
    }
}

public class FFmpegConversionException : Exception, IFFmpegConversionResult
{
    public FFmpegConversionException(string message, string outputBuffer, IFFmpegClArguments arguments, DateTime startTime, DateTime endTime, bool isFinished)
        : base(message) => (OutputBuffer, Arguments, StartTime, EndTime, IsFinished) = (outputBuffer, arguments, startTime, endTime, isFinished);
    public string OutputBuffer { get; }
    public IFFmpegClArguments Arguments { get; }
    public IEnumerable<IFFmpegOutputSink> Outputs => Arguments.Outputs.Select(x => x.Sink);
    public DateTime StartTime { get; }
    public DateTime EndTime { get; }
    public TimeSpan Duration => EndTime - StartTime;
    public bool IsFinished { get; }
}
