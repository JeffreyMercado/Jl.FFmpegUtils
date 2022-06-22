namespace Jl.FFmpegUtils;

public interface IFFmpegOutputSink
{
    string Serialize();
    Task<IFFmpegOutputBuilder> CreateOutputBuilderAsync(IReadOnlyList<IFFmpegInput> inputs, CancellationToken cancellationToken = default);
}
