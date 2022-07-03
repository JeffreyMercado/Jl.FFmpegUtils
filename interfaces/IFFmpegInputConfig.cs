namespace Jl.FFmpegUtils;

public interface IFFmpegInputConfig
{
    IFFmpegInputSource Source { get; }
    Action<IFFmpegInputBuilder, int>? Config { get; }

    Task<IFFmpegInput> BuildAsync(IFFmpegProvider provider, int index, CancellationToken cancellationToken = default);
}
