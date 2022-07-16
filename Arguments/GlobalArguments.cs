namespace Jl.FFmpegUtils.Arguments;

public record OverwriteArgument() : SimpleArgument("-y"), ISimpleGlobalArgument;
public record DoNotOverwriteArgument() : SimpleArgument("-n"), ISimpleGlobalArgument;
