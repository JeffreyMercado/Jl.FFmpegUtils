namespace Jl.FFmpegUtils.Arguments;

public record OutputAudioCodecArgument(AudioCodec Value, int? StreamIndex) : SimpleArgument<AudioCodec>($"-c:a", Value, StreamIndex), ISimpleOutputAudioStreamArgument;
public record OutputAudioBitrateArgument(string Value) : SimpleArgument<string>($"-b:a", Value), ISimpleOutputAudioStreamArgument;
