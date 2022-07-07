namespace Jl.FFmpegUtils;

public interface IFFmpegInputConfig
{
    IFFmpegInputSource Source { get; }
    Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder> Config { get; }

    Task<IFFmpegInput> BuildAsync(IFFmpegProvider provider, int index, CancellationToken cancellationToken = default);
}
