using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static partial class OutputComplexFilterBuilderExtensions
{
    private static ComplexFilterArgument<T> ComplexFilter<T>(T value) => new ComplexFilterArgument<T>(value);
}
