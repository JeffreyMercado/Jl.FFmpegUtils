namespace Jl.FFmpegUtils;

public interface IFFmpegInputAudioStream : IFFmpegInputMediaStream
{
    IAudioStream Stream { get; }
}
