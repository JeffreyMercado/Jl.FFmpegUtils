using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public record FFmpegOutputConfig(IFFmpegOutputSink Sink, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder> Config) : IFFmpegOutputConfig
{
    public async Task<IFFmpegClArguments> BuildAsync(IFFmpegProvider provider, IEnumerable<IFFmpegInputConfig> inputConfigs, IEnumerable<IFFmpegGlobalArgument> globalArguments, CancellationToken cancellationToken = default)
    {
        var inputs = (
            await Task.WhenAll(inputConfigs.Select((x, i) => x.BuildAsync(provider, i, cancellationToken))).ConfigureAwait(false)
        ).ToImmutableArray();
        var outputBuilder = await Sink.CreateOutputBuilderAsync(inputs, cancellationToken).ConfigureAwait(false);
        return new FFmpegClArguments(globalArguments.ToImmutableArray(), inputs, outputBuilder.Configure(Config).Build());
    }
}
