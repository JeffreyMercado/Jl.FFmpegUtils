namespace Jl.FFmpegUtils.Presets;

public static class PresetExtensions
{
    public static IFFmpegOutputBuilder FastStandardOutputFormat(
        this IFFmpegOutputBuilder builder,
        Func<IFFmpegOutputVideoStreamBuilder, IFFmpegOutputVideoStreamBuilder>? configureVideo = default,
        Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder>? configureAudio = default
    ) =>
        builder.AddVideoStream(v => v
            .CodecLibx264(x => x
                .Profile("main")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.fast)
                .Crf(22)
            )
            .FpsMax(30)
            .Configure(configureVideo)
        )
        .AddAudioStream(a => a
            .Codec(AudioCodec.aac)
            .Bitrate("160k")
            .Configure(configureAudio)
        );

    public static IFFmpegOutputBuilder HQStandardOutputFormat(
        this IFFmpegOutputBuilder builder,
        Func<IFFmpegOutputVideoStreamBuilder, IFFmpegOutputVideoStreamBuilder>? configureVideo = default,
        Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder>? configureAudio = default
    ) =>
        builder.AddVideoStream(v => v
            .CodecLibx264(x => x
                .Profile("high")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.slow)
                .Crf(20)
            )
            .FpsMax(30)
            .Configure(configureVideo)
        )
        .AddAudioStream(a => a
            .Codec(AudioCodec.aac)
            .Bitrate("160k")
            .Configure(configureAudio)
        );
}
