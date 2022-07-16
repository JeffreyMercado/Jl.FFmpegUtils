namespace Jl.FFmpegUtils;

public interface IFFmpegOutputConfig
{
    IFFmpegOutputSink Sink { get; }
    Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder> Config { get; }

    Task<IFFmpegOutput> BuildAsync(IFFmpegProvider provider, IReadOnlyList<IFFmpegInput> inputs, CancellationToken cancellationToken = default);
}
