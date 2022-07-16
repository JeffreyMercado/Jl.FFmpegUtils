namespace Jl.FFmpegUtils.Arguments;

public record VideoCodecArgument(VideoCodec Value, int? StreamIndex) : SimpleArgument<VideoCodec>($"-c:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
public record VideoBitrateArgument(string Value) : SimpleArgument<string>($"-b:v", Value), ISimpleOutputVideoStreamArgument;
public record VideoFpsMaxArgument(int Value, int? StreamIndex) : SimpleArgument<int>($"-fpsmax:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
