using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static class OutputBuilderExtensions
{
    public static IFFmpegOutputBuilder Configure(this IFFmpegOutputBuilder builder, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config)
    {
        return config?.Invoke(builder) ?? builder;
    }
    public static IFFmpegOutputBuilder Configure(this IFFmpegOutputBuilder builder, Action<IFFmpegOutputBuilder>? config)
    {
        config?.Invoke(builder);
        return builder;
    }

    /// <summary>-map [stream]</summary>
    public static IFFmpegOutputBuilder Map(this IFFmpegOutputBuilder builder, IFFmpegInputMediaStream stream) => Map(builder, $"[{stream.Identifier}]");
    /// <summary>-map [stream] [-map ...rest]</summary>
    public static IFFmpegOutputBuilder Map(this IFFmpegOutputBuilder builder, string stream, params string[] rest)
    {
        builder.AddArgument(new MapArgument(stream));
        foreach (var s in rest)
            builder.AddArgument(new MapArgument(s));
        return builder;
    }
}
