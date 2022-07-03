using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Jl.FFmpegUtils;

public record FFmpegConversion(IFFmpegClArguments Arguments) : IFFmpegConversion
{
    public event DataReceivedEventHandler? OutputDataReceived;
    public event DataReceivedEventHandler? ProgressDataReceived;

    public async Task<IFFmpegConversionResult> ConvertAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default)
    {
        var arguments = Arguments.SerializeArguments();
        var result = await provider.ConvertAsync(arguments, new DataObserver(this), cancellationToken).ConfigureAwait(false);
        return new FFmpegConversionResult(Arguments, result.StartTime, result.EndTime);
    }
    private void OnOutputDataReceived(DataReceivedEventArgs e)
    {
        OutputDataReceived?.Invoke(this, e);
    }
    private void OnProgressDataReceived(DataReceivedEventArgs e)
    {
        ProgressDataReceived?.Invoke(this, e);
    }

    private record FFmpegConversionResult(IFFmpegClArguments Arguments, DateTime StartTime, DateTime EndTime) : IFFmpegConversionResult;

    private record DataObserver(FFmpegConversion Conversion) : IObserver<DataReceivedEventArgs>
    {
        private readonly TaskCompletionSource tcs = new TaskCompletionSource();

        public Task Task => tcs.Task;

        public void OnNext(DataReceivedEventArgs value)
        {
            if (value.Data is string data)
            {
                if (IsProgressData(data))
                    Conversion.OnProgressDataReceived(value);
                else
                    Conversion.OnOutputDataReceived(value);
            }

            static bool IsProgressData(string data) => Regex.IsMatch(data, @"^frame=\s*[0-9.]+");
        }

        public void OnError(Exception error)
        {
            tcs.TrySetException(error);
        }

        public void OnCompleted()
        {
            tcs.TrySetResult();
        }
    }
}
