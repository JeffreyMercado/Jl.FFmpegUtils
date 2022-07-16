namespace Jl.FFmpegUtils.Arguments;

public record ComplexFilterArgument<T>(T Value) : SimpleArgument<T>("-filter_complex", Value), ISimpleOutputComplexFilterArgument;
