namespace Jl.FFmpegUtils.Arguments;

public record OutputVideoCodecArgument(VideoCodec Value, int? StreamIndex) : SimpleArgument<VideoCodec>($"-c:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
public record OutputVideoBitrateArgument(string Value) : SimpleArgument<string>($"-b:v", Value), ISimpleOutputVideoStreamArgument;
public record OutputVideoFpsMaxArgument(int Value, int? StreamIndex) : SimpleArgument<int>($"-fpsmax:v", Value, StreamIndex), ISimpleOutputVideoStreamArgument;
public record OutputVideoFpsModeArgument(FpsMode Value, int? Index) : SimpleArgument<FpsMode>("-fps_mode", Value, Index), ISimpleOutputVideoStreamArgument;
