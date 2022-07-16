namespace Jl.FFmpegUtils.Arguments;

public record OutputMapArgument(string Value) : SimpleArgument<string>("-map", Value.TryQuoted()), ISimpleOutputArgument;
public record OutputDeinterlaceArgument() : SimpleArgument<string>("-vf", "yadif"), ISimpleOutputArgument;
