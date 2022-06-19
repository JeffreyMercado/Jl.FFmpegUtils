namespace Jl.FFmpegUtils;

public interface IVideoStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Video;
}
