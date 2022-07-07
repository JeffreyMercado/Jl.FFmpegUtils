namespace Jl.FFmpegUtils;

public static partial class OutputAudioStreamBuilderExtensions
{
    public static IFFmpegOutputAudioStreamBuilder Configure(this IFFmpegOutputAudioStreamBuilder builder, Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder>? config)
    {
        return config?.Invoke(builder) ?? builder;
    }

    internal record AudioCodecArgument(AudioCodec Value, int? StreamIndex) : SimpleArgument<AudioCodec>($"-c:a", Value, StreamIndex), ISimpleOutputAudioStreamArgument;
    /// <summary>-c:a[:index] [codec]</summary>
    public static IFFmpegOutputAudioStreamBuilder Codec(this IFFmpegOutputAudioStreamBuilder builder, AudioCodec codec, int? index = default) => builder.AddArgument(new AudioCodecArgument(codec, index));

    internal record AudioBitrateArgument(string Value) : SimpleArgument<string>($"-b:a", Value), ISimpleOutputAudioStreamArgument;
    /// <summary>-b:a [bitrate]</summary>
    public static IFFmpegOutputAudioStreamBuilder Bitrate(this IFFmpegOutputAudioStreamBuilder builder, string bitrate) => builder.AddArgument(new AudioBitrateArgument(bitrate));
    /// <summary>-b:a [bitrate]</summary>
    public static IFFmpegOutputAudioStreamBuilder Bitrate(this IFFmpegOutputAudioStreamBuilder builder, int bitrate) => Bitrate(builder, $"{bitrate}");
}
