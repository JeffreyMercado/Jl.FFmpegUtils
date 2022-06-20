namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private record FFmpegInputAudioStream(IFFmpegInput Input, IAudioStream Stream) : FFmpegInputMediaStream<IAudioStream>(Input, Stream), IFFmpegInputAudioStream;
}
