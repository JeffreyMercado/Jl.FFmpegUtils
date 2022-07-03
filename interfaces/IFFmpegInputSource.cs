namespace Jl.FFmpegUtils;

public interface IFFmpegInputSource
{
    string Serialize();
    Task<IMediaInfo> GetMediaInfoAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default);
}
