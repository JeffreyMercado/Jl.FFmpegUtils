using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static class ClArgumentsBuilderExtensions
{
    /// <summary>-y</summary>
    public static IFFmpegClArgumentsBuilder Overwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new GlobalOverwriteArgument());

    /// <summary>-n</summary>
    public static IFFmpegClArgumentsBuilder DoNotOverwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new GlobalDoNotOverwriteArgument());
}
