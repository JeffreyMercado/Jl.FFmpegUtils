namespace Jl.FFmpegUtils;

internal interface ISimpleOutputVideoStreamArgument : ISimpleArgument, ISimpleOutputArgument, IFFmpegOutputVideoStreamArgument
{
    IFFmpegOutputArgument IFFmpegOutputVideoStreamArgument.Create(IFFmpegOutputVideoStreamBuilder builder) => this;
}

internal interface ISimpleOutputVideoStreamArgument<T> : ISimpleOutputVideoStreamArgument, IFFmpegOutputVideoStreamArgument<T>
    where T : ILibTag
{
}
