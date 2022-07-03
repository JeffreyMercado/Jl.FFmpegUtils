namespace Jl.FFmpegUtils;

public interface IFFmpegOutputConfig
{
    IFFmpegOutputSink Sink { get; }
    Action<IFFmpegOutputBuilder>? Config { get; }

    Task<IFFmpegClArguments> BuildAsync(IFFmpegProvider provider, IEnumerable<IFFmpegInputConfig> inputConfigs, IEnumerable<IFFmpegGlobalArgument> globalArguments, CancellationToken cancellationToken = default);
}
