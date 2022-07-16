namespace Jl.FFmpegUtils.Arguments;

public record InputOutputFormatArgument(string Value) : SimpleArgument<string>("-f", Value), ISimpleInputOutputArgument;
public record InputOutputStreamSeekArgument(TimeSpan Value) : SimpleArgument<TimeSpan>("-ss", Value), ISimpleInputOutputArgument;
public record InputOutputTimeDurationArgument(TimeSpan Value) : SimpleArgument<TimeSpan>("-t", Value), ISimpleInputOutputArgument;
public record InputOutputTimeToArgument(TimeSpan Value) : SimpleArgument<TimeSpan>("-to", Value), ISimpleInputOutputArgument;
