namespace Jl.FFmpegUtils;

public interface IMediaStream
{
    IMediaSource Source { get; }
    MediaStreamType Type { get; }
    int Index { get; }
    string Codec { get; }
}
