namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private partial class FFmpegInputMediaStreams
    {
        private record FFmpegInputVideoStream(IFFmpegInput Input, IVideoStream Stream, int VideoIndex) : IFFmpegInputVideoStream
        {
        }
    }
}
