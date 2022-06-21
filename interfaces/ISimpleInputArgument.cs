namespace Jl.FFmpegUtils;

public interface ISimpleInputArgument : ISimpleArgument, IFFmpegInputArgument
{
    string IFFmpegInputArgument.SerializeInputArgument(IFFmpegInput input) => Serialize();
}
