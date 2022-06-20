namespace Jl.FFmpegUtils;

public record FileOutputSink(string FilePath) : IFFmpegOutputSink
{
    public string Serialize() => FilePath.TryQuoted();

    public Task<IFFmpegOutputBuilder> CreateOutputBuilderAsync(IReadOnlyList<IFFmpegInput> inputs)
    {
        var builder = FFmpegOutput.CreateBuilder(this, inputs);
        return Task.FromResult(builder);
    }
}
