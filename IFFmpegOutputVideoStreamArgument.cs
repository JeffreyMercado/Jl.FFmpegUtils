namespace Jl.FFmpegUtils;

public interface IFFmpegOutputVideoStreamArgument
{
    IFFmpegOutputArgument Create(IFFmpegOutputVideoStreamBuilder builder);
}

public interface IFFmpegOutputVideoStreamBuilder : IFFmpegOutputStreamBuilder
{
    IFFmpegOutputVideoStreamBuilder AddArgument(IFFmpegOutputVideoStreamArgument argument);
}
