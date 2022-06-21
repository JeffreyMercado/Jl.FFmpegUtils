namespace Jl.FFmpegUtils;

public interface IFFmpegInputAudioStream : IFFmpegInputMediaStream
{
    MediaStreamType IFFmpegInputMediaStream.Type => MediaStreamType.Audio;
    IAudioStream Stream { get; }
}
