namespace Jl.FFmpegUtils;

public interface IFFmpegOutputVideoStreamArgument
{
    IFFmpegOutputArgument Create(IFFmpegOutputVideoStreamBuilder builder);
}

public interface IFFmpegOutputVideoStreamBuilder : IFFmpegOutputStreamBuilder
{
    IList<IFFmpegOutputVideoStreamArgument> Arguments { get; }

    IFFmpegOutputVideoStreamBuilder AddArgument(IFFmpegOutputVideoStreamArgument argument);
}
