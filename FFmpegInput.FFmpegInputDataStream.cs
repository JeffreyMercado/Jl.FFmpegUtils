namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private partial class FFmpegInputMediaStreams
    {
        private record FFmpegInputDataStream(IFFmpegInput Input, IDataStream Stream, int DataIndex) : IFFmpegInputDataStream
        {
        }
    }
}
