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
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default);
    IFFmpegClArgumentsBuilder WithOutput(string outputPath, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default);
    IFFmpegClArgumentsBuilder WithOutput(IFFmpegOutputSink sink, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default);
    Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default);
}
