namespace Jl.FFmpegUtils;

internal interface ISimpleOutputArgument : ISimpleArgument, IFFmpegOutputArgument
{
    string IFFmpegOutputArgument.SerializeOutputArgument(IFFmpegOutput output) => Serialize();
}
