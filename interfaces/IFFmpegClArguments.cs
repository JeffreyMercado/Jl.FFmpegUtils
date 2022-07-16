namespace Jl.FFmpegUtils;

public interface IFFmpegClArguments
{
    IReadOnlyList<IFFmpegGlobalArgument> Globals { get; }
    IReadOnlyList<IFFmpegInput> Inputs { get; }
    IReadOnlyList<IFFmpegOutput> Outputs { get; }

    string SerializeArguments();
    string SerializeArgumentsReadable();
    IFFmpegConversion CreateConversion();
}

public interface IFFmpegClArgumentsBuilder
{
    IList<IFFmpegGlobalArgument> GlobalArguments { get; }
    IList<IFFmpegInputConfig> InputConfigs { get; }
    IList<IFFmpegOutputConfig> OutputConfigs { get; }

    IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument);
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config);
    IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default);
    IFFmpegClArgumentsBuilder AddOutput(string outputPath, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default);
    IFFmpegClArgumentsBuilder AddOutput(IFFmpegOutputSink sink, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default);
    Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default);
}
