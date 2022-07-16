namespace Jl.FFmpegUtils;

using Arguments;

public static class InputOutputBuilderExtensions
{
    /// <summary>-f [format]</summary>
    public static IFFmpegInputBuilder Format(this IFFmpegInputBuilder builder, string format) => builder.AddArgument(new InputOutputFormatArgument(format));
    /// <summary>-f [format]</summary>
    public static IFFmpegOutputBuilder Format(this IFFmpegOutputBuilder builder, string format) => builder.AddArgument(new InputOutputFormatArgument(format));

    public static IFFmpegInputBuilder StreamSeek(this IFFmpegInputBuilder builder, string position) => StreamSeek(builder, TimeSpan.Parse(position));
    public static IFFmpegInputBuilder StreamSeek(this IFFmpegInputBuilder builder, TimeSpan position) => builder.AddArgument(new InputOutputStreamSeekArgument(position));
    public static IFFmpegOutputBuilder StreamSeek(this IFFmpegOutputBuilder builder, string position) => StreamSeek(builder, TimeSpan.Parse(position));
    public static IFFmpegOutputBuilder StreamSeek(this IFFmpegOutputBuilder builder, TimeSpan position) => builder.AddArgument(new InputOutputStreamSeekArgument(position));

    public static IFFmpegInputBuilder TimeDuration(this IFFmpegInputBuilder builder, string duration) => TimeDuration(builder, TimeSpan.Parse(duration));
    public static IFFmpegInputBuilder TimeDuration(this IFFmpegInputBuilder builder, TimeSpan duration) => builder.AddArgument(new InputOutputTimeDurationArgument(duration));
    public static IFFmpegOutputBuilder TimeDuration(this IFFmpegOutputBuilder builder, string duration) => TimeDuration(builder, TimeSpan.Parse(duration));
    public static IFFmpegOutputBuilder TimeDuration(this IFFmpegOutputBuilder builder, TimeSpan duration) => builder.AddArgument(new InputOutputTimeDurationArgument(duration));

    public static IFFmpegInputBuilder TimeTo(this IFFmpegInputBuilder builder, string duration) => TimeTo(builder, TimeSpan.Parse(duration));
    public static IFFmpegInputBuilder TimeTo(this IFFmpegInputBuilder builder, TimeSpan duration) => builder.AddArgument(new InputOutputTimeToArgument(duration));
    public static IFFmpegOutputBuilder TimeTo(this IFFmpegOutputBuilder builder, string duration) => TimeTo(builder, TimeSpan.Parse(duration));
    public static IFFmpegOutputBuilder TimeTo(this IFFmpegOutputBuilder builder, TimeSpan duration) => builder.AddArgument(new InputOutputTimeToArgument(duration));
}
