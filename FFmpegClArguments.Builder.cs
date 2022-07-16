using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments
{
    public record Builder(IFFmpegProvider Provider) : IFFmpegClArgumentsBuilder
    {
        public IList<IFFmpegGlobalArgument> GlobalArguments { get; } = new List<IFFmpegGlobalArgument>();
        public IList<IFFmpegInputConfig> InputConfigs { get; } = new List<IFFmpegInputConfig>();
        public IList<IFFmpegOutputConfig> OutputConfigs { get; } = new List<IFFmpegOutputConfig>();

        public IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument)
        {
            GlobalArguments.Add(
                argument ?? throw new ArgumentNullException(nameof(argument))
            );
            return this;
        }

        public IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config) =>
            AddInput(inputPath, config != null ? (input, i) => config.Invoke(input) : throw new ArgumentNullException(nameof(config)));
        public IFFmpegClArgumentsBuilder AddInput(string inputPath, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default)
        {
            var source = new FileInputSource(
                inputPath ?? throw new ArgumentNullException(nameof(inputPath))
            );
            return AddInput(source, config);
        }

        public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, IFFmpegInputBuilder> config) =>
            AddInput(source, config != null ? (input, i) => config.Invoke(input) : throw new ArgumentNullException(nameof(config)));
        public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Func<IFFmpegInputBuilder, int, IFFmpegInputBuilder>? config = default)
        {
            var inputConfig = new FFmpegInputConfig(
                source ?? throw new ArgumentNullException(nameof(source)),
                config ?? ((b, _) => b)
            );
            InputConfigs.Add(inputConfig);
            return this;
        }

        public IFFmpegClArgumentsBuilder AddOutput(string outputPath, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default)
        {
            var sink = new FileOutputSink(
                outputPath ?? throw new ArgumentNullException(nameof(outputPath))
            );
            return AddOutput(sink, config);
        }
        public IFFmpegClArgumentsBuilder AddOutput(IFFmpegOutputSink sink, Func<IFFmpegOutputBuilder, IFFmpegOutputBuilder>? config = default)
        {
            var outputConfig = new FFmpegOutputConfig(
                sink ?? throw new ArgumentNullException(nameof(sink)),
                config ?? (b => b)
            );
            OutputConfigs.Add(outputConfig);
            return this;
        }

        public async Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default)
        {
            if (!InputConfigs.Any())
                throw new InvalidOperationException($"inputs are required");
            if (!OutputConfigs.Any())
                throw new InvalidOperationException($"output is required");
            var globals = GlobalArguments.ToImmutableArray();
            var inputs = (
                await Task.WhenAll(InputConfigs.Select((x, i) => x.BuildAsync(Provider, i, cancellationToken))).ConfigureAwait(false)
            ).ToImmutableArray();
            var outputs = (
                await Task.WhenAll(OutputConfigs.Select(x => x.BuildAsync(Provider, inputs, cancellationToken))).ConfigureAwait(false)
            ).ToImmutableArray();
            return new FFmpegClArguments(globals, inputs, outputs);
        }
    }
}
