namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private partial class FFmpegInputMediaStreams
    {
        private record FFmpegInputSubtitleStream(IFFmpegInput Input, ISubtitleStream Stream, int SubtitleIndex) : IFFmpegInputSubtitleStream
        {
        }
    }
}
