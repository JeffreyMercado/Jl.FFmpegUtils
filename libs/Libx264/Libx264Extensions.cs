namespace Jl.FFmpegUtils;

using Libx264;

public static class Libx264Extensions
{
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> CodecLibx264(this IFFmpegOutputVideoStreamBuilder builder, Action<IFFmpegOutputVideoStreamBuilder<Libx264Tag>>? config = default, int? index = default)
    {
        builder.AddArgument(new OutputVideoStreamBuilderExtensions.VideoCodecArgument(VideoCodec.libx264, index));
        return builder.WithTag(config);
    }

    internal record Libx264ProfileArgument(string Value) : SimpleArgument<string>($"-profile:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    /// <summary>-profile:v [profile]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Profile(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string profile) => builder.AddArgument(new Libx264ProfileArgument(profile));

    internal record Libx264LevelArgument(string Value) : SimpleArgument<string>($"-level:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    /// <summary>-level:v [level]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Level(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string level) => builder.AddArgument(new Libx264LevelArgument(level));

    internal record Libx264PresetArgument(Libx264Preset Value) : SimpleArgument<Libx264Preset>($"-preset:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    /// <summary>-preset:v [preset]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Preset(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, Libx264Preset preset) => builder.AddArgument(new Libx264PresetArgument(preset));

    internal record Libx264CrfArgument(int Value) : SimpleArgument<int>($"-crf:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    /// <summary>-crf:v [crf]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Crf(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, int crf) => builder.AddArgument(new Libx264CrfArgument(crf));

    internal record Libx264TuneArgument(Libx264Tune Value) : SimpleArgument<Libx264Tune>($"-tune:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
    /// <summary>-tune:v [tune]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Tune(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, Libx264Tune tune) => builder.AddArgument(new Libx264TuneArgument(tune));
}
