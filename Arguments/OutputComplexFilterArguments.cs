namespace Jl.FFmpegUtils.Arguments;

public record OutputComplexFilterArgument<T>(T Value) : SimpleArgument<T>("-filter_complex", Value), ISimpleOutputComplexFilterArgument;
