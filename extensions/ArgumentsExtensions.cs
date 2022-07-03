namespace Jl.FFmpegUtils;

public static class ArgumentsExtensions
{
    public static string? GetInputFilePath(this IFFmpegInput input)
    {
        return input.Source is IFileMediaSource fileMediaSource
            ? fileMediaSource.FilePath
            : null;
    }

    public static string? GetOutputFilePath(this IFFmpegOutput output)
    {
        return output.Sink is IFileOutputSink fileOutputSink
            ? fileOutputSink.FilePath
            : null;
    }
}
