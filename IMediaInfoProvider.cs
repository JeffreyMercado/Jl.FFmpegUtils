namespace Jl.FFmpegUtils;

public interface IMediaInfoProvider
{
    Task<IMediaInfo> GetMediaInfoAsync(IMediaSource source, CancellationToken cancellationToken = default);
}
