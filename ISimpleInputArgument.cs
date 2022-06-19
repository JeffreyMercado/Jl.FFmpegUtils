namespace Jl.FFmpegUtils;

internal interface ISimpleInputArgument : ISimpleArgument, IFFmpegInputArgument
{
    string IFFmpegInputArgument.SerializeInputArgument(IFFmpegInput input) => Serialize();
}
