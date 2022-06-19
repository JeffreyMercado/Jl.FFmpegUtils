namespace Jl.FFmpegUtils;

public interface IMediaStream
{
    MediaStreamType Type { get; }
    int Index { get; }
}
