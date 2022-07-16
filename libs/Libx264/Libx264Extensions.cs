namespace Jl.FFmpegUtils;

using Jl.FFmpegUtils.Arguments;
using Jl.FFmpegUtils.Arguments.Libx264;

using Libx264;

public static class Libx264Extensions
{
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> CodecLibx264(this IFFmpegOutputVideoStreamBuilder builder, Func<IFFmpegOutputVideoStreamBuilder<Libx264Tag>, IFFmpegOutputVideoStreamBuilder<Libx264Tag>>? config = default, int? index = default)
    {
        builder.AddArgument(new VideoCodecArgument(VideoCodec.libx264, index));
        return builder.WithTag(config);
    }

    /// <summary>-profile:v [profile]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Profile(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string profile) => builder.AddArgument(new Libx264ProfileArgument(profile));

    /// <summary>-level:v [level]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Level(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, string level) => builder.AddArgument(new Libx264LevelArgument(level));

    /// <summary>-preset:v [preset]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Preset(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, Libx264Preset preset) => builder.AddArgument(new Libx264PresetArgument(preset));

    /// <summary>-crf:v [crf]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Crf(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, int crf) => builder.AddArgument(new Libx264CrfArgument(crf));

    /// <summary>-tune:v [tune]</summary>
    public static IFFmpegOutputVideoStreamBuilder<Libx264Tag> Tune(this IFFmpegOutputVideoStreamBuilder<Libx264Tag> builder, Libx264Tune tune) => builder.AddArgument(new Libx264TuneArgument(tune));
}
