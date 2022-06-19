namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private partial class FFmpegInputMediaStreams
    {
        private record FFmpegInputAudioStream(IFFmpegInput Input, IAudioStream Stream, int AudioIndex) : IFFmpegInputAudioStream
        {
        }
    }
}
