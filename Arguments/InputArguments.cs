namespace Jl.FFmpegUtils.Arguments;

public record InputStreamLoopArgument(int Value) : SimpleArgument<int>("-stream_loop", Value), ISimpleInputArgument;
public record InputRateArgument(string Value) : SimpleArgument<string>("-r", Value), ISimpleInputArgument;
public record InputTimeOffsetArgument(TimeSpan Value) : SimpleArgument<TimeSpan>("-itsoffset", Value), ISimpleInputArgument;
public record InputStreamSeekEofArgument(TimeSpan Value) : SimpleArgument<TimeSpan>("-sseof", Value), ISimpleInputArgument;
