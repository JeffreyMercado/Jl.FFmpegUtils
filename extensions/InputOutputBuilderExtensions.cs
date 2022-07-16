using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static class InputOutputBuilderExtensions
{
    /// <summary>-f [format]</summary>
    public static IFFmpegInputBuilder Format(this IFFmpegInputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));
    /// <summary>-f [format]</summary>
    public static IFFmpegOutputBuilder Format(this IFFmpegOutputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));
}
