namespace Jl.FFmpegUtils;

public interface IFFmpegOutputComplexFilterArgument : IFFmpegOutputArgument
{
}

public interface IFFmpegOutputComplexFilterBuilder
{
    IFFmpegOutputComplexFilterBuilder AddComponent(string component);
    IFFmpegOutputComplexFilterArgument Build();
}
