namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private record FFmpegInputVideoStream(IFFmpegInput Input, IVideoStream Stream) : FFmpegInputMediaStream<IVideoStream>(Input, Stream), IFFmpegInputVideoStream;
}
