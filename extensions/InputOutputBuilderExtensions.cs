namespace Jl.FFmpegUtils;

public static class InputOutputBuilderExtensions
{
    internal record FormatArgument(string Value) : SimpleArgument<string>("-f", Value), ISimpleInputOutputArgument;
    /// <summary>-f [format]</summary>
    public static IFFmpegInputBuilder Format(this IFFmpegInputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));
    /// <summary>-f [format]</summary>
    public static IFFmpegOutputBuilder Format(this IFFmpegOutputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));
}
