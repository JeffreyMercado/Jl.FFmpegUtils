using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments
{
    public record Builder(IMediaInfoProvider Provider) : IFFmpegClArgumentsBuilder
    {
        private readonly ImmutableArray<IFFmpegGlobalArgument>.Builder globalArguments = ImmutableArray.CreateBuilder<IFFmpegGlobalArgument>();
        private readonly List<InputConfig> inputConfigs = new List<InputConfig>();
        private OutputConfig? outputConfig;

        public IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument)
        {
            globalArguments.Add(
                argument ?? throw new ArgumentNullException(nameof(argument))
            );
            return this;
        }

        public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder> config) =>
            AddInput(inputPath, config != null ? (input, i) => config.Invoke(input) : throw new ArgumentNullException(nameof(config)));
        public IFFmpegClArgumentsBuilder AddInput(string inputPath, Action<IFFmpegInputBuilder, int>? config = default)
        {
            var source = new FileInputSource(
                inputPath ?? throw new ArgumentNullException(nameof(inputPath))
            );
            return AddInput(source, config);
        }

        public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder> config) =>
            AddInput(source, config != null ? (input, i) => config.Invoke(input) : throw new ArgumentNullException(nameof(config)));
        public IFFmpegClArgumentsBuilder AddInput(IFFmpegInputSource source, Action<IFFmpegInputBuilder, int>? config = default)
        {
            var inputConfig = new InputConfig(
                source ?? throw new ArgumentNullException(nameof(source)),
                config
            );
            inputConfigs.Add(inputConfig);
            return this;
        }

        public IFFmpegClArgumentsBuilder WithOutput(string outputPath, Action<IFFmpegOutputBuilder>? config = default)
        {
            var sink = new FileOutputSink(
                outputPath ?? throw new ArgumentNullException(nameof(outputPath))
            );
            return WithOutput(sink, config);
        }
        public IFFmpegClArgumentsBuilder WithOutput(IFFmpegOutputSink sink, Action<IFFmpegOutputBuilder>? config = default)
        {
            if (outputConfig != null)
                throw new InvalidOperationException($"output already set");
            var _outputConfig = new OutputConfig(
                sink ?? throw new ArgumentNullException(nameof(sink)),
                config
            );
            outputConfig = _outputConfig;
            return this;
        }

        public async Task<IFFmpegClArguments> BuildAsync()
        {
            if (!inputConfigs.Any())
                throw new InvalidOperationException($"inputs are required");
            if (outputConfig == null)
                throw new InvalidOperationException($"output is required");
            return await outputConfig.BuildAsync(Provider, inputConfigs, globalArguments.ToImmutable()).ConfigureAwait(false);
        }

        private record InputConfig(IFFmpegInputSource Source, Action<IFFmpegInputBuilder, int>? Config)
        {
            public async Task<IFFmpegInput> BuildAsync(IMediaInfoProvider provider, int index)
            {
                var builder = await Source.CreateInputBuilderAsync(provider).ConfigureAwait(false);
                Config?.Invoke(builder, index);
                return builder.Build(index);
            }
        }

        private record OutputConfig(IFFmpegOutputSink Sink, Action<IFFmpegOutputBuilder>? Config)
        {
            public async Task<IFFmpegClArguments> BuildAsync(IMediaInfoProvider provider, IEnumerable<InputConfig> inputConfigs, IReadOnlyList<IFFmpegGlobalArgument> globalArguments)
            {
                var inputs = (
                    await Task.WhenAll(inputConfigs.Select((x, i) => x.BuildAsync(provider, i))).ConfigureAwait(false)
                ).ToImmutableArray();
                var outputBuilder = await Sink.CreateOutputBuilderAsync(inputs).ConfigureAwait(false);
                Config?.Invoke(outputBuilder);
                return new FFmpegClArguments(globalArguments, inputs, outputBuilder.Build());
            }
        }
    }
}
