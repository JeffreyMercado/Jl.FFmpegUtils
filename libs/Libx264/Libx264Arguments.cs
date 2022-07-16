using Jl.FFmpegUtils.Libx264;

namespace Jl.FFmpegUtils.Arguments.Libx264;

public record Libx264ProfileArgument(string Value) : SimpleArgument<string>($"-profile:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
public record Libx264LevelArgument(string Value) : SimpleArgument<string>($"-level:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
public record Libx264PresetArgument(Libx264Preset Value) : SimpleArgument<Libx264Preset>($"-preset:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
public record Libx264CrfArgument(int Value) : SimpleArgument<int>($"-crf:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
public record Libx264TuneArgument(Libx264Tune Value) : SimpleArgument<Libx264Tune>($"-tune:v", Value), ISimpleOutputVideoStreamArgument<Libx264Tag>;
