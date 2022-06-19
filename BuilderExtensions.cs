namespace Jl.FFmpegUtils;

public static partial class BuilderExtensions
{
    private record OverwriteArgument() : SimpleArgument("-y"), ISimpleGlobalArgument;
    public static IFFmpegClArgumentsBuilder Overwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new OverwriteArgument());

    private record DoNotOverwriteArgument() : SimpleArgument("-n"), ISimpleGlobalArgument;
    public static IFFmpegClArgumentsBuilder DoNotOverwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new DoNotOverwriteArgument());

    private record StreamLoopArgument(int Value) : SimpleArgument<int>("-stream_loop", Value), ISimpleInputArgument;
    public static IFFmpegInputBuilder StreamLoop(this IFFmpegInputBuilder builder, int value) => builder.AddArgument(new StreamLoopArgument(value));

    private record FormatArgument(string Value) : SimpleArgument<string>("-f", Value), ISimpleInputOutputArgument;
    public static IFFmpegInputBuilder Format(this IFFmpegInputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));
    public static IFFmpegOutputBuilder Format(this IFFmpegOutputBuilder builder, string format) => builder.AddArgument(new FormatArgument(format));

    private record MapArgument(string Value) : SimpleArgument<string>("-map", Value.TryQuoted()), ISimpleOutputArgument;
    public static IFFmpegOutputBuilder Map(this IFFmpegOutputBuilder builder, IFFmpegInputMediaStream stream) => Map(builder, $"[{stream.Identifier}]");
    public static IFFmpegOutputBuilder Map(this IFFmpegOutputBuilder builder, string stream, params string[] rest)
    {
        builder.AddArgument(new MapArgument(stream));
        foreach (var s in rest)
            builder.AddArgument(new MapArgument(s));
        return builder;
    }
}
