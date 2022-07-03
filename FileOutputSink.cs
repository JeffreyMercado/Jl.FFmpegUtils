namespace Jl.FFmpegUtils;

public record FileOutputSink(string FilePath) : IFFmpegOutputSink, IFileOutputSink
{
    public string Serialize() => FilePath.TryQuoted();

    public Task<IFFmpegOutputBuilder> CreateOutputBuilderAsync(IReadOnlyList<IFFmpegInput> inputs, CancellationToken cancellationToken = default)
    {
        var builder = FFmpegOutput.CreateBuilder(this, inputs);
        return Task.FromResult(builder);
    }
}
