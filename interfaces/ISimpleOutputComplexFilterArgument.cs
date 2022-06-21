namespace Jl.FFmpegUtils;

public interface ISimpleOutputComplexFilterArgument : ISimpleArgument, IFFmpegOutputComplexFilterArgument
{
    string IFFmpegOutputArgument.SerializeOutputArgument(IFFmpegOutput output) => Serialize();
}
