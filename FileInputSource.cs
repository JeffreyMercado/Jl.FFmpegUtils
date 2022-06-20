namespace Jl.FFmpegUtils;

public record FileInputSource(string FilePath) : IFFmpegInputSource, IFileMediaSource
{
    public string Serialize() => $"-i {FilePath.TryQuoted()}";

    public async Task<IFFmpegInputBuilder> CreateInputBuilderAsync(IMediaInfoProvider provider)
    {
        var mediaInfo = await provider.GetMediaInfoAsync(this).ConfigureAwait(false);
        return FFmpegInput.CreateBuilder(this, mediaInfo);
    }
}
