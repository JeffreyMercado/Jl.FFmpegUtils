namespace Jl.FFmpegUtils;

internal interface ISimpleGlobalArgument : ISimpleArgument, IFFmpegGlobalArgument
{
    string IFFmpegGlobalArgument.SerializeGlobalArgument() => Serialize();
}
