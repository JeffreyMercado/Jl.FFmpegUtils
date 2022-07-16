namespace Jl.FFmpegUtils.Arguments;

public record AudioCodecArgument(AudioCodec Value, int? StreamIndex) : SimpleArgument<AudioCodec>($"-c:a", Value, StreamIndex), ISimpleOutputAudioStreamArgument;
public record AudioBitrateArgument(string Value) : SimpleArgument<string>($"-b:a", Value), ISimpleOutputAudioStreamArgument;
