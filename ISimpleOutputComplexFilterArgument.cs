namespace Jl.FFmpegUtils;

internal interface ISimpleOutputComplexFilterArgument : ISimpleArgument, IFFmpegOutputComplexFilterArgument
{
    string IFFmpegOutputArgument.SerializeOutputArgument(IFFmpegOutput output) => Serialize();
}
