namespace Jl.FFmpegUtils.Arguments;

public record GlobalOverwriteArgument() : SimpleArgument("-y"), ISimpleGlobalArgument;
public record GlobalDoNotOverwriteArgument() : SimpleArgument("-n"), ISimpleGlobalArgument;
public record GlobalVsyncArgument(int Value, int? Index) : SimpleArgument<int>("-vsync", Value, Index), ISimpleGlobalArgument;
