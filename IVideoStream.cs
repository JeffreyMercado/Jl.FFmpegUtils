namespace Jl.FFmpegUtils;

public interface IVideoStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Video;
    int Width { get; }
    int Height { get; }
    string Ratio { get; }
    string PixelFormat { get; }
    double Framerate { get; }
    TimeSpan Duration { get; }
    long Bitrate { get; }

    int? Default { get; }
    int? Forced { get; }
    int? Rotation { get; }
}
