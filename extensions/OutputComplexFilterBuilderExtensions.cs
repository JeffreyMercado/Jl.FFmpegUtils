using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static partial class OutputComplexFilterBuilderExtensions
{
    private static OutputComplexFilterArgument<T> ComplexFilter<T>(T value) => new OutputComplexFilterArgument<T>(value);
}
