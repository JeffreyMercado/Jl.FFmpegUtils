namespace Jl.FFmpegUtils;

public interface IMediaInfoProvider
{
    Task<IMediaInfo> GetMediaInfoAsync(string filePath);
}
