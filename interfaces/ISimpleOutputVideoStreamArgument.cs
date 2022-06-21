namespace Jl.FFmpegUtils;

public interface ISimpleOutputVideoStreamArgument : ISimpleArgument, ISimpleOutputArgument, IFFmpegOutputVideoStreamArgument
{
    IFFmpegOutputArgument IFFmpegOutputVideoStreamArgument.Create(IFFmpegOutputVideoStreamBuilder builder) => this;
}

public interface ISimpleOutputVideoStreamArgument<T> : ISimpleOutputVideoStreamArgument, IFFmpegOutputVideoStreamArgument<T>
    where T : ILibTag
{
}
