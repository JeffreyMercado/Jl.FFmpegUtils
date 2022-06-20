namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private record FFmpegInputSubtitleStream(IFFmpegInput Input, ISubtitleStream Stream) : FFmpegInputMediaStream<ISubtitleStream>(Input, Stream), IFFmpegInputSubtitleStream;
}
