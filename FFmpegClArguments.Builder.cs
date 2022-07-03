namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments
{
    public record Builder(IFFmpegProvider Provider) : IFFmpegClArgumentsBuilder
    {
        public IList<IFFmpegGlobalArgument> GlobalArguments { get; } = new List<IFFmpegGlobalArgument>();
        public IList<IFFmpegInputConfig> InputConfigs { get; } = new List<IFFmpegInputConfig>();
        public IFFmpegOutputConfig? OutputConfig { get; set; }

        public IFFmpegClArgumentsBuilder AddGlobal(IFFmpegGlobalArgument argument)
        {
            GlobalArguments.Add(
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
            var inputConfig = new FFmpegInputConfig(
                source ?? throw new ArgumentNullException(nameof(source)),
                config
            );
            InputConfigs.Add(inputConfig);
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
            OutputConfig = new FFmpegOutputConfig(
                sink ?? throw new ArgumentNullException(nameof(sink)),
                config
            );
            return this;
        }

        public async Task<IFFmpegClArguments> BuildAsync(CancellationToken cancellationToken = default)
        {
            if (!InputConfigs.Any())
                throw new InvalidOperationException($"inputs are required");
            if (OutputConfig == null)
                throw new InvalidOperationException($"output is required");
            return await OutputConfig.BuildAsync(Provider, InputConfigs, GlobalArguments, cancellationToken).ConfigureAwait(false);
        }
    }
}
