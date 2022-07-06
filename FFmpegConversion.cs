using System.Diagnostics;

namespace Jl.FFmpegUtils;

public record FFmpegConversion(IFFmpegClArguments Arguments) : IFFmpegConversion
{
    public event EventHandler<ConversionData>? DataReceived;
    public event EventHandler<ConversionProgress>? ProgressReceived;

    public async Task<IFFmpegConversionResult> ConvertAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default)
    {
        var arguments = Arguments.SerializeArguments();
        var observer = new DataObserver(this);
        var result = await provider.ConvertAsync(arguments, observer, cancellationToken).ConfigureAwait(false);
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

    private record FFmpegConversionResult(IFFmpegClArguments Arguments, DateTime StartTime, DateTime EndTime) : IFFmpegConversionResult;

    private class DataObserver : IObserver<DataReceivedEventArgs>
    {
        private readonly TaskCompletionSource tcs = new TaskCompletionSource();
        private readonly FFmpegConversion conversion;
        private readonly long? size;
        private readonly TimeSpan? duration;
        public DataObserver(FFmpegConversion conversion)
        {
            this.conversion = conversion;
            var inputs = conversion.Arguments.Inputs;
            (duration, size) = inputs.Count == 1 && inputs.Single() is IFFmpegInput input
                ? (input.Duration, input.Size)
                : default;
        }

        public Task Task => tcs.Task;

        public void OnNext(DataReceivedEventArgs value)
        {
            if (value.Data is string data)
            {
                if (ConversionProgress.TryParse(data, size, duration) is ConversionProgress progress)
                    conversion.OnProgressReceived(progress);
                else
                    conversion.OnDataReceived(new ConversionData(data));
            }
        }

        public void OnError(Exception error)
        {
            // suppress cancellations here
            if (error is not OperationCanceledException)
                tcs.TrySetException(error);
        }

        public void OnCompleted()
        {
            tcs.TrySetResult();
        }
    }
}
