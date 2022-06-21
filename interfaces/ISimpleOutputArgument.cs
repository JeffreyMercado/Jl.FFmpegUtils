namespace Jl.FFmpegUtils;

public interface ISimpleOutputArgument : ISimpleArgument, IFFmpegOutputArgument
{
    string IFFmpegOutputArgument.SerializeOutputArgument(IFFmpegOutput output) => Serialize();
}
