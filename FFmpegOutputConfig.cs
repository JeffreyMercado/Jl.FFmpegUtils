namespace Jl.FFmpegUtils;

public record FFmpegOutputConfig(IFFmpegOutputSink Sink, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder> Config) : IFFmpegOutputConfig
{
    public async Task<IFFmpegOutput> BuildAsync(IFFmpegProvider provider, IReadOnlyList<IFFmpegInput> inputs, CancellationToken cancellationToken = default)
    {
        var outputBuilder = await Sink.CreateOutputBuilderAsync(inputs, cancellationToken).ConfigureAwait(false);
        return outputBuilder.Configure(Config).Build();
    }
}
