namespace Jl.FFmpegUtils;

using Libx264;

public static class Libx264Extensions
{
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> CodecLibx264(this IFFmpegOutputVideoStreamBuilder builder, Action<IFFmpegOutputVideoStreamBuilder<Libx264Tag>>? config = default, int? index = default)
    {
        builder.AddArgument(new OutputVideoStreamBuilderExtensions.VideoCodecArgument(VideoCodec.libx264, index));
        return builder.WithTag<Libx264Tag>(config);
    }

    internal record VideoProfileArgument(string Value) : SimpleArgument<string>($"-profile:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Profile(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string profile) => builder.AddArgument(new VideoProfileArgument(profile));

    internal record VideoLevelArgument(string Value) : SimpleArgument<string>($"-level:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Level(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string level) => builder.AddArgument(new VideoLevelArgument(level));

    internal record VideoPresetArgument(Libx264Preset Value) : SimpleArgument<Libx264Preset>($"-preset:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Preset(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, Libx264Preset preset) => builder.AddArgument(new VideoPresetArgument(preset));

    internal record VideoCrfArgument(int Value) : SimpleArgument<int>($"-crf:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Crf(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, int crf) => builder.AddArgument(new VideoCrfArgument(crf));
}
