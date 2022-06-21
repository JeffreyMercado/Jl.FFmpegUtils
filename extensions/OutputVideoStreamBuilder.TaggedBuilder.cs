namespace Jl.FFmpegUtils;

public static partial class OutputVideoStreamBuilderExtensions
{
    public static IFFmpegOutputVideoStreamBuilder<T> AsTagged<T>(this IFFmpegOutputVideoStreamBuilder builder)
        where T : ILibTag
    {
        if (builder is IFFmpegOutputVideoStreamBuilder<T> taggedBuilder)
            return taggedBuilder;
        if (builder is ITaggedFFmpegOutputVideoStreamBuilder tagged)
            return new TaggedOutputVideoStreamBuilder<T>(tagged.Builder);
        return new TaggedOutputVideoStreamBuilder<T>(builder);
    }

    public static IFFmpegOutputVideoStreamBuilder<T> WithTag<T>(this IFFmpegOutputVideoStreamBuilder builder, Action<IFFmpegOutputVideoStreamBuilder<T>>? config)
        where T : ILibTag
    {
        var taggedBuilder = builder.AsTagged<T>();
        config?.Invoke(taggedBuilder);
        return taggedBuilder;
    }
}
