namespace Jl.FFmpegUtils;

public interface IFFmpegOutputComplexFilterArgument : IFFmpegOutputArgument
{
}

public interface IFFmpegOutputComplexFilterBuilder
{
    IList<string> Components { get; }

    IFFmpegOutputComplexFilterBuilder AddComponent(string component);
    IFFmpegOutputComplexFilterArgument Build();
}
