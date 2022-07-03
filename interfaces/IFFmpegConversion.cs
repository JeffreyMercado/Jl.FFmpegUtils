using System.Diagnostics;

namespace Jl.FFmpegUtils;

public interface IFFmpegConversion
{
    IFFmpegClArguments Arguments { get; }
    event DataReceivedEventHandler? OutputDataReceived;
    event DataReceivedEventHandler? ProgressDataReceived;

    Task<IFFmpegConversionResult> ConvertAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default);
}
