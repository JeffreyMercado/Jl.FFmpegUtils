using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments
{
    public record Builder(IMediaInfoProvider Provider) : IFFmpegClArgumentsBuilder
    {
        private readonly ImmutableArray<IFFmpegGlobalArgument>.Builder globalArguments = ImmutableArray.CreateBuilder<IFFmpegGlobalArgument>();
        private readonly List<InputConfig> inputConfigs = new List<InputConfig>();

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

        public Task<IFFmpegClArguments> BuildAsync(string outputPath, Action<IFFmpegOutputBuilder>? config = default)
        {
            var sink = new FileOutputSink(
                outputPath ?? throw new ArgumentNullException(nameof(outputPath))
            );
            return BuildAsync(sink, config);
        }
        public async Task<IFFmpegClArguments> BuildAsync(IFFmpegOutputSink sink, Action<IFFmpegOutputBuilder>? config = default)
        {
            if (sink == null)
                throw new ArgumentNullException(nameof(sink));
            if (!inputConfigs.Any())
                throw new InvalidOperationException($"inputs are required");

            var inputs = (
                await Task.WhenAll(inputConfigs.Select((x, i) => x.BuildAsync(Provider, i))).ConfigureAwait(false)
            ).ToImmutableArray();
            var outputBuilder = await sink.CreateOutputBuilderAsync(inputs).ConfigureAwait(false);
            config?.Invoke(outputBuilder);
            return new FFmpegClArguments(globalArguments.ToImmutable(), inputs, outputBuilder.Build());
        }

        private record InputConfig(IFFmpegInputSource Source, Action<IFFmpegInputBuilder, int>? Config = default)
        {
            public async Task<IFFmpegInput> BuildAsync(IMediaInfoProvider provider, int index)
            {
                var builder = await Source.CreateInputBuilderAsync(provider).ConfigureAwait(false);
                Config?.Invoke(builder, index);
                return builder.Build(index);
            }
        }
    }
}
