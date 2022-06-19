namespace Jl.FFmpegUtils;

public interface IFFmpegInputSource
{
    string Serialize();
    Task<IFFmpegInputBuilder> CreateInputBuilderAsync(IMediaInfoProvider provider);
}
