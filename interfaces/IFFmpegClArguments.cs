namespace Jl.FFmpegUtils;

public interface IFFmpegClArguments
{
    IReadOnlyList<IFFmpegGlobalArgument> Globals { get; }
    IReadOnlyList<IFFmpegInput> Inputs { get; }
    IFFmpegOutput Output { get; }

    string SerializeArguments();
    string SerializeArgumentsReadable();
    IFFmpegConversion CreateConversion();
}

public interface IFFmpegClArgumentsBuilder
{
    public IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument);
    public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder> config);
    public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder, int>? config = default);
    public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder> config);
    public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder, int>? config = default);
    public IFFmpegClArgumentsBuilder WithOutput(string outputPath, Action<IFFmpegOutputBuilder>? config = default);
    public IFFmpegClArgumentsBuilder WithOutput(IFFmpegOutputSink sink, Action<IFFmpegOutputBuilder>? config = default);
    public Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default);
}
