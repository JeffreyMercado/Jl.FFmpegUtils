namespace Jl.FFmpegUtils;

using Arguments;

public static partial class OutputAudioStreamBuilderExtensions
{
    public static IFFmpegOutputAudioStreamBuilder Configure(this IFFmpegOutputAudioStreamBuilder builder, Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder>? config)
    {
        return config?.Invoke(builder) ?? builder;
    }

    /// <summary>-c:a[:index] [codec]</summary>
    public static IFFmpegOutputAudioStreamBuilder Codec(this IFFmpegOutputAudioStreamBuilder builder, AudioCodec codec, int? index = default) => builder.AddArgument(new OutputAudioCodecArgument(codec, index));

    /// <summary>-b:a [bitrate]</summary>
    public static IFFmpegOutputAudioStreamBuilder Bitrate(this IFFmpegOutputAudioStreamBuilder builder, string bitrate) => builder.AddArgument(new OutputAudioBitrateArgument(bitrate));
    /// <summary>-b:a [bitrate]</summary>
    public static IFFmpegOutputAudioStreamBuilder Bitrate(this IFFmpegOutputAudioStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");
}
