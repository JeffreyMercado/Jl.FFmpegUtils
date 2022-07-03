namespace Jl.FFmpegUtils;

public interface IFFmpegConversion
{
    IFFmpegClArguments Arguments { get; }
    event EventHandler<ConversionData>? DataReceived;
    event EventHandler<ConversionProgress>? ProgressReceived;

    Task<IFFmpegConversionResult> ConvertAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default);
}
