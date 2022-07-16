namespace Jl.FFmpegUtils.Arguments;

public record FormatArgument(string Value) : SimpleArgument<string>("-f", Value), ISimpleInputOutputArgument;
