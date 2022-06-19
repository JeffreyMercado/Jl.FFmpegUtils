namespace Jl.FFmpegUtils.Presets;

public static class PresetExtensions
{
    public static IFFmpegOutputBuilder StandardOutputFormat(this IFFmpegOutputBuilder builder) => builder
        .AddVideoStream(v =>
            v.Codec(VideoCodec.libx264)
                .Profile("main")
                .Level("3.1")
                .Preset(Preset.fast)
                .Crf(21)
        )
        .AddAudioStream(a =>
            a.Codec(AudioCodec.aac)
                .Bitrate("160k")
        );
}
