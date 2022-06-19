namespace Jl.FFmpegUtils;

public interface IFFmpegClArguments
{
    IReadOnlyList<IFFmpegGlobalArgument> Globals { get; }
    IReadOnlyList<IFFmpegInput> Inputs { get; }
    IFFmpegOutput Output { get; }

    string SerializeArguments();
    string SerializeArgumentsReadable();
}

public interface IFFmpegClArgumentsBuilder
{
    public IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument);
    public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder> config);
    public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder, int>? config = default);
    public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder> config);
    public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder, int>? config = default);
    public Task<IFFmpegClArguments> BuildAsync(string outputPath, Action<IFFmpegOutputBuilder>? config = default);
    public Task<IFFmpegClArguments> BuildAsync(IFFmpegOutputSink sink, Action<IFFmpegOutputBuilder>? config = default);
}
