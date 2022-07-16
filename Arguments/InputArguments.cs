namespace Jl.FFmpegUtils.Arguments;

public record StreamLoopArgument(int Value) : SimpleArgument<int>("-stream_loop", Value), ISimpleInputArgument;
