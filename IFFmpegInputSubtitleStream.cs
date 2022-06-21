namespace Jl.FFmpegUtils;

public interface IFFmpegInputSubtitleStream : IFFmpegInputMediaStream
{
    MediaStreamType IFFmpegInputMediaStream.Type => MediaStreamType.Subtitle;
    ISubtitleStream Stream { get; }
}
