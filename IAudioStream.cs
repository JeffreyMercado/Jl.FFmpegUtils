namespace Jl.FFmpegUtils;

public interface IAudioStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Audio;
}
