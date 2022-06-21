namespace Jl.FFmpegUtils;

public interface ISimpleGlobalArgument : ISimpleArgument, IFFmpegGlobalArgument
{
    string IFFmpegGlobalArgument.SerializeGlobalArgument() => Serialize();
}
