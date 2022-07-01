namespace Jl.FFmpegUtils;

public static class InputBuilderExtensions
{
    internal record StreamLoopArgument(int Value) : SimpleArgument<int>("-stream_loop", Value), ISimpleInputArgument;
    /// <summary>-stream_loop [value]</summary>
    public static IFFmpegInputBuilder StreamLoop(this IFFmpegInputBuilder builder, int value) => builder.AddArgument(new StreamLoopArgument(value));
}
