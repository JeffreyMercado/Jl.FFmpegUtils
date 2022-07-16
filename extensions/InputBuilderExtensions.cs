using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

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
    public static IFFmpegInputBuilder StreamLoop(this IFFmpegInputBuilder builder, int value) => builder.AddArgument(new StreamLoopArgument(value));
}
