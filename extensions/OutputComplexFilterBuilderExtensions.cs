namespace Jl.FFmpegUtils;

using Arguments;

public static partial class OutputComplexFilterBuilderExtensions
{
    private static OutputComplexFilterArgument<T> ComplexFilter<T>(T value) => new OutputComplexFilterArgument<T>(value);
}
