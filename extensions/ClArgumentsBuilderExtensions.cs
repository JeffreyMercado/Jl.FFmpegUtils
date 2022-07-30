namespace Jl.FFmpegUtils;

using Arguments;

public static class ClArgumentsBuilderExtensions
{
    public static IFFmpegClArgumentsBuilder Configure(this IFFmpegClArgumentsBuilder builder, Func<IFFmpegClArgumentsBuilder, IFFmpegClArgumentsBuilder>? config)
    {
        return config?.Invoke(builder) ?? builder;
    }

    /// <summary>-y</summary>
    public static IFFmpegClArgumentsBuilder Overwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new GlobalOverwriteArgument());

    /// <summary>-n</summary>
    public static IFFmpegClArgumentsBuilder DoNotOverwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new GlobalDoNotOverwriteArgument());
}
