namespace Jl.FFmpegUtils.Presets;

public static class PresetExtensions
{
    public static IFFmpegOutputBuilder FastStandardOutputFormat(this IFFmpegOutputBuilder builder) => builder
        .AddVideoStream(v => v
            .CodecLibx264(x => x
                .Profile("main")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.fast)
                .Crf(22)
            )
            .FpsMax(30)
        )
        .AddAudioStream(a => a
            .Codec(AudioCodec.aac)
            .Bitrate("160k")
        );

    public static IFFmpegOutputBuilder HQStandardOutputFormat(this IFFmpegOutputBuilder builder) => builder
        .AddVideoStream(v => v
            .CodecLibx264(x => x
                .Profile("high")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.slow)
                .Crf(20)
            )
            .FpsMax(30)
        )
        .AddAudioStream(a => a
            .Codec(AudioCodec.aac)
            .Bitrate("160k")
        );
}
