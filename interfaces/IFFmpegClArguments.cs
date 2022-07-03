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
    IList<IFFmpegGlobalArgument> GlobalArguments { get; }
    IList<IFFmpegInputConfig> InputConfigs { get; }
    IFFmpegOutputConfig? OutputConfig { get; set; }

    IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument);
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder, int>? config = default);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder, int>? config = default);
    IFFmpegClArgumentsBuilder WithOutput(string outputPath, Action<IFFmpegOutputBuilder>? config = default);
    IFFmpegClArgumentsBuilder WithOutput(IFFmpegOutputSink sink, Action<IFFmpegOutputBuilder>? config = default);
    Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default);
}
