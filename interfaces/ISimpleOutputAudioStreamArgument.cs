namespace Jl.FFmpegUtils;

public interface ISimpleOutputAudioStreamArgument : ISimpleArgument, ISimpleOutputArgument, IFFmpegOutputAudioStreamArgument
{
    IFFmpegOutputArgument IFFmpegOutputAudioStreamArgument.Create(IFFmpegOutputAudioStreamBuilder builder) => this;
}
