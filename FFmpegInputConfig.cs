namespace Jl.FFmpegUtils;

public record FFmpegInputConfig(IFFmpegInputSource Source, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder> Config) : IFFmpegInputConfig
{
    public async Task<IFFmpegInput> BuildAsync(IFFmpegProvider provider, int index, CancellationToken cancellationToken = default)
    {
        var mediaInfo = await Source.GetMediaInfoAsync(provider, cancellationToken).ConfigureAwait(false);
        return FFmpegInput.CreateBuilder(Source, mediaInfo)
            .Configure(index, Config)
            .Build(index);
    }
}
