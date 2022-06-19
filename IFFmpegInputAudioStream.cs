namespace Jl.FFmpegUtils;

public interface IFFmpegInputAudioStream : IFFmpegInputMediaStream
{
    IAudioStream Stream { get; }
    int AudioIndex { get; }
    string IFFmpegInputMediaStream.Identifier => $"{Input.Index}:{Stream.Index}";
}
