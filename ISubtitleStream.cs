namespace Jl.FFmpegUtils;

public interface ISubtitleStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Subtitle;
}
