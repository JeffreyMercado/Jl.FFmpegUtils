namespace Jl.FFmpegUtils;

public static partial class BuilderExtensions
{
    private record VideoCodecArgument(VideoCodec Value, int? StreamIndex) : SimpleArgument<VideoCodec>($"-c:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Codec(this IFFmpegOutputVideoStreamBuilder builder, VideoCodec codec, int? index = default) => builder.AddArgument(new VideoCodecArgument(codec, index));

    private record VideoBitrateArgument(string Value) : SimpleArgument<string>($"-b:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, string bitrate) => builder.AddArgument(new VideoBitrateArgument(bitrate));
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");

    private record VideoProfileArgument(string Value) : SimpleArgument<string>($"-profile:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Profile(this IFFmpegOutputVideoStreamBuilder builder, string profile) => builder.AddArgument(new VideoProfileArgument(profile));

    private record VideoLevelArgument(string Value) : SimpleArgument<string>($"-level:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Level(this IFFmpegOutputVideoStreamBuilder builder, string level) => builder.AddArgument(new VideoLevelArgument(level));

    private record VideoPresetArgument(Preset Value) : SimpleArgument<Preset>($"-preset:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Preset(this IFFmpegOutputVideoStreamBuilder builder, Preset preset) => builder.AddArgument(new VideoPresetArgument(preset));

    private record VideoCrfArgument(int Value) : SimpleArgument<int>($"-crf:v", Value), ISimpleOutputVideoStreamArgument;
    public static IFFmpegOutputVideoStreamBuilder Crf(this IFFmpegOutputVideoStreamBuilder builder, int crf) => builder.AddArgument(new VideoCrfArgument(crf));
}
