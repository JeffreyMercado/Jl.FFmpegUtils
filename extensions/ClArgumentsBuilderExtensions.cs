namespace Jl.FFmpegUtils;

public static partial class ClArgumentsBuilderExtensions
{
    internal record OverwriteArgument() : SimpleArgument("-y"), ISimpleGlobalArgument;
    /// <summary>-y</summary>
    public static IFFmpegClArgumentsBuilder Overwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new OverwriteArgument());

    internal record DoNotOverwriteArgument() : SimpleArgument("-n"), ISimpleGlobalArgument;
    /// <summary>-n</summary>
    public static IFFmpegClArgumentsBuilder DoNotOverwrite(this IFFmpegClArgumentsBuilder builder) => builder.AddGlobal(new DoNotOverwriteArgument());
}
