namespace Jl.FFmpegUtils;

public interface IFFmpegInputVideoStream : IFFmpegInputMediaStream
{
    MediaStreamType IFFmpegInputMediaStream.Type => MediaStreamType.Video;
    IVideoStream Stream { get; }
}
