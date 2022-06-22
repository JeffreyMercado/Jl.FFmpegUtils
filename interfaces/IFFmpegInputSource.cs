namespace Jl.FFmpegUtils;

public interface IFFmpegInputSource
{
    string Serialize();
    Task<IMediaInfo> GetMediaInfoAsync(IMediaInfoProvider provider, CancellationToken cancellationToken = default);
}
