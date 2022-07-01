namespace Jl.FFmpegUtils;

public static partial class OutputVideoStreamBuilderExtensions
{
    internal record VideoCodecArgument(VideoCodec Value, int? StreamIndex) : SimpleArgument<VideoCodec>($"-c:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
    /// <summary>-c:v[:index] [codec]</summary>
    public static IFFmpegOutputVideoStreamBuilder Codec(this IFFmpegOutputVideoStreamBuilder builder, VideoCodec codec, int? index = default) => builder.AddArgument(new VideoCodecArgument(codec, index));

    internal record VideoBitrateArgument(string Value) : SimpleArgument<string>($"-b:v", Value), ISimpleOutputVideoStreamArgument;
    /// <summary>-b:v [bitrate]</summary>
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, string bitrate) => builder.AddArgument(new VideoBitrateArgument(bitrate));
    /// <summary>-b:v [bitrate]</summary>
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");

    internal record VideoFpsMaxArgument(int Value, int? StreamIndex) : SimpleArgument<int>($"-fpsmax:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
    /// <summary>-fpsmax:v[:index] [fps]</summary>
    public static IFFmpegOutputVideoStreamBuilder FpsMax(this IFFmpegOutputVideoStreamBuilder builder, int fps, int? index = default) => builder.AddArgument(new VideoFpsMaxArgument(fps, index));
}
