namespace Jl.FFmpegUtils;

public record FFmpegInputConfig(IFFmpegInputSource Source, Action<IFFmpegInputBuilder, int>? Config) : IFFmpegInputConfig
{
    public async Task<IFFmpegInput> BuildAsync(IFFmpegProvider provider, int index, CancellationToken cancellationToken = default)
    {
        var mediaInfo = await Source.GetMediaInfoAsync(provider, cancellationToken).ConfigureAwait(false);
        var builder = FFmpegInput.CreateBuilder(Source, mediaInfo);
        Config?.Invoke(builder, index);
        return builder.Build(index);
    }
}
