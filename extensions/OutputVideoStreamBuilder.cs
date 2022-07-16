using Jl.FFmpegUtils.Arguments;

namespace Jl.FFmpegUtils;

public static partial class OutputVideoStreamBuilderExtensions
{
    public static IFFmpegOutputVideoStreamBuilder Configure(this IFFmpegOutputVideoStreamBuilder builder, Func<IFFmpegOutputVideoStreamBuilder, IFFmpegOutputVideoStreamBuilder>? config)
    {
        return config?.Invoke(builder) ?? builder;
    }

    /// <summary>-c:v[:index] [codec]</summary>
    public static IFFmpegOutputVideoStreamBuilder Codec(this IFFmpegOutputVideoStreamBuilder builder, VideoCodec codec, int? index = default) => builder.AddArgument(new OutputVideoCodecArgument(codec, index));

    /// <summary>-b:v [bitrate]</summary>
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, string bitrate) => builder.AddArgument(new OutputVideoBitrateArgument(bitrate));
    /// <summary>-b:v [bitrate]</summary>
    public static IFFmpegOutputVideoStreamBuilder Bitrate(this IFFmpegOutputVideoStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");

    /// <summary>-fpsmax:v[:index] [fps]</summary>
    public static IFFmpegOutputVideoStreamBuilder FpsMax(this IFFmpegOutputVideoStreamBuilder builder, int fps, int? index = default) => builder.AddArgument(new OutputVideoFpsMaxArgument(fps, index));

    public static IFFmpegOutputVideoStreamBuilder FpsMode(this IFFmpegOutputVideoStreamBuilder builder, FpsMode fpsMode, int? index = default) => builder.AddArgument(new OutputVideoFpsModeArgument(fpsMode, index));
}
