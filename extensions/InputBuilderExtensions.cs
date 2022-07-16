namespace Jl.FFmpegUtils;

using Arguments;

public static class InputBuilderExtensions
{
    public static IFFmpegInputBuilder Configure(this IFFmpegInputBuilder builder, int index, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config)
    {
        return config?.Invoke(builder, index) ?? builder;
    }
    public static IFFmpegInputBuilder Configure(this IFFmpegInputBuilder builder, int index, Action<IFFmpegInputBuilder, int>? config)
    {
        config?.Invoke(builder, index);
        return builder;
    }

    /// <summary>-stream_loop [value]</summary>
    public static IFFmpegInputBuilder StreamLoop(this IFFmpegInputBuilder builder, int value) => builder.AddArgument(new InputStreamLoopArgument(value));

    public static IFFmpegInputBuilder Rate(this IFFmpegInputBuilder builder, decimal rate) => Rate(builder, $"{rate}");
    public static IFFmpegInputBuilder Rate(this IFFmpegInputBuilder builder, string rate) => builder.AddArgument(new InputRateArgument(rate));

    public static IFFmpegInputBuilder InputTimeOffset(this IFFmpegInputBuilder builder, string offset) => InputTimeOffset(builder, TimeSpan.Parse(offset));
    public static IFFmpegInputBuilder InputTimeOffset(this IFFmpegInputBuilder builder, TimeSpan offset) => builder.AddArgument(new InputTimeOffsetArgument(offset));

    public static IFFmpegInputBuilder StreamSeekEof(this IFFmpegInputBuilder builder, string position) => StreamSeekEof(builder, TimeSpan.Parse(position));
    public static IFFmpegInputBuilder StreamSeekEof(this IFFmpegInputBuilder builder, TimeSpan position) => builder.AddArgument(new InputStreamSeekEofArgument(position));
}
