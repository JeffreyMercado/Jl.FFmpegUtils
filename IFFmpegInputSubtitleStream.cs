namespace Jl.FFmpegUtils;

public interface IFFmpegInputSubtitleStream : IFFmpegInputMediaStream
{
    ISubtitleStream Stream { get; }
}
