namespace Jl.FFmpegUtils;

public interface IFileMediaSource : IMediaSource
{
    string FilePath { get; }
}
