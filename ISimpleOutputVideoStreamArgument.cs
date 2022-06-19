namespace Jl.FFmpegUtils;

internal interface ISimpleOutputVideoStreamArgument : ISimpleArgument, ISimpleOutputArgument, IFFmpegOutputVideoStreamArgument
{
    IFFmpegOutputArgument IFFmpegOutputVideoStreamArgument.Create(IFFmpegOutputVideoStreamBuilder builder) => this;
}
