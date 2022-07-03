namespace Jl.FFmpegUtils;

public record FileInputSource(string FilePath) : IFFmpegInputSource, IFileMediaSource
{
    public string Serialize() => $"-i {FilePath.TryQuoted()}";

    public async Task<IMediaInfo> GetMediaInfoAsync(IFFmpegProvider provider, CancellationToken cancellationToken = default)
    {
        return await provider.GetMediaInfoAsync(this, cancellationToken).ConfigureAwait(false);
    }
}
