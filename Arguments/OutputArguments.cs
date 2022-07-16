namespace Jl.FFmpegUtils.Arguments;

public record MapArgument(string Value) : SimpleArgument<string>("-map", Value.TryQuoted()), ISimpleOutputArgument;
