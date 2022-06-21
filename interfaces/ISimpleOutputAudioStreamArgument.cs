namespace Jl.FFmpegUtils;

internal interface ISimpleOutputAudioStreamArgument : ISimpleArgument, ISimpleOutputArgument, IFFmpegOutputAudioStreamArgument
{
    IFFmpegOutputArgument IFFmpegOutputAudioStreamArgument.Create(IFFmpegOutputAudioStreamBuilder builder) => this;
}
