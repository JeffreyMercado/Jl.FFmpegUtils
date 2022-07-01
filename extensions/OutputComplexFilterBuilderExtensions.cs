namespace Jl.FFmpegUtils;

public static partial class OutputComplexFilterBuilderExtensions
{
    internal record ComplexFilterArgument<T>(T Value) : SimpleArgument<T>("-filter_complex", Value), ISimpleOutputComplexFilterArgument;
    private static ComplexFilterArgument<T> ComplexFilter<T>(T value) => new ComplexFilterArgument<T>(value);
}
