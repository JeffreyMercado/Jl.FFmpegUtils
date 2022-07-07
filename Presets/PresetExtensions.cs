namespace Jl.FFmpegUtils.Presets;

public static class PresetExtensions
{
    public static IFFmpegOutputBuilder FastStandardOutputFormat(
        this IFFmpegOutputBuilder builder,
        Action<IFFmpegOutputVideoStreamBuilder>? configureVideo = default,
        Action<IFFmpegOutputAudioStreamBuilder>? configureAudio = default
    ) =>
        builder.AddVideoStream(v =>
        {
            v.CodecLibx264(x => x
                .Profile("main")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.fast)
                .Crf(22)
            )
            .FpsMax(30);
            configureVideo?.Invoke(v);
        })
        .AddAudioStream(a =>
        {
            a.Codec(AudioCodec.aac).Bitrate("160k");
            configureAudio?.Invoke(a);
        });

    public static IFFmpegOutputBuilder HQStandardOutputFormat(
        this IFFmpegOutputBuilder builder,
        Action<IFFmpegOutputVideoStreamBuilder>? configureVideo = default,
        Action<IFFmpegOutputAudioStreamBuilder>? configureAudio = default
    ) =>
        builder.AddVideoStream(v =>
        {
            v.CodecLibx264(x => x
                .Profile("high")
                .Level("4.0")
                .Preset(Libx264.Libx264Preset.slow)
                .Crf(20)
            )
            .FpsMax(30);
            configureVideo?.Invoke(v);
        })
        .AddAudioStream(a =>
        {
            a.Codec(AudioCodec.aac).Bitrate("160k");
            configureAudio?.Invoke(a);
        });
}
