namespace Jl.FFmpegUtils;

public static partial class OutputVideoStreamBuilderExtensions
{
    internal record VideoCodecArgument(VideoCodec Value, int? StreamIndex) : SimpleArgument<VideoCodec>($"-c:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Codec(this IFFmpegOutputVideoStreamBuilder builder, VideoCodec codec, int? index = default) => builder.AddArgument(new VideoCodecArgument(codec, index));

    internal record VideoBitrateArgument(string Value) : SimpleArgument<string>($"-b:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, string bitrate) => builder.AddArgument(new VideoBitrateArgument(bitrate));
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");
}
