namespace Jl.FFmpegUtils;

public static partial class OutputVideoStreamBuilderExtensions
{
    public static IFFmpegOutputVideoStreamBuilder<T> AsTagged<T>(this IFFmpegOutputVideoStreamBuilder builder)
        where T : ILibTag
    {
        return builder switch
        {
            IFFmpegOutputVideoStreamBuilder<T> taggedBuilder => taggedBuilder,
            ITaggedFFmpegOutputVideoStreamBuilder tagged => new TaggedOutputVideoStreamBuilder<T>(tagged.Builder),
            _ => new TaggedOutputVideoStreamBuilder<T>(builder),
        };
    }

    public static IFFmpegOutputVideoStreamBuilder<T> WithTag<T>(this IFFmpegOutputVideoStreamBuilder builder, Action<IFFmpegOutputVideoStreamBuilder<T>>? config)
        where T : ILibTag
    {
        var taggedBuilder = builder.AsTagged<T>();
        config?.Invoke(taggedBuilder);
        return taggedBuilder;
    }
}
