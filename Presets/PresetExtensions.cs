namespace Jl.FFmpegUtils.Presets;

public static class PresetExtensions
{
    public static IFFmpegOutputBuilder StandardOutputFormat(this IFFmpegOutputBuilder builder) => builder
        .AddVideoStream(v =>
            v.CodecLibx264()
                .Profile("main")
                .Level("3.1")
                .Preset(Libx264.Libx264Preset.fast)
                .Crf(21)
        )
        .AddAudioStream(a =>
            a.Codec(AudioCodec.aac)
                .Bitrate("160k")
        );
}
