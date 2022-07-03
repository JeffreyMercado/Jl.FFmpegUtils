using System.Diagnostics;

namespace Jl.FFmpegUtils;

public interface IFFmpegProvider
{
    Task<IMediaInfo> GetMediaInfoAsync(IMediaSource source, CancellationToken cancellationToken = default);
    Task<IConversionResult> ConvertAsync(string arguments, IObserver<DataReceivedEventArgs> outputDataObserver, CancellationToken cancellationToken = default);
}
