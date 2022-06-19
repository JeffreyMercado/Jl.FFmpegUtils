namespace Jl.FFmpegUtils;

public record FileInputSource(string FilePath) : IFFmpegInputSource
{
    public string Serialize() => $"-i {FilePath.TryQuoted()}";

    public async Task<IFFmpegInputBuilder> CreateInputBuilderAsync(IMediaInfoProvider provider)
    {
        var mediaInfo = await provider.GetMediaInfoAsync(FilePath).ConfigureAwait(false);
        return FFmpegInput.Builder.Create(this, mediaInfo);
    }
}
