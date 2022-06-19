using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder(IFFmpegOutputSink Sink, IReadOnlyList<IFFmpegInput> Inputs) : IFFmpegOutputBuilder
    {
        public static IFFmpegOutputBuilder Create(IFFmpegOutputSink sink, IReadOnlyList<IFFmpegInput> inputs) => new Builder(
            sink ?? throw new ArgumentNullException(nameof(sink)),
            inputs ?? throw new ArgumentNullException(nameof(inputs))
        );

        private readonly ImmutableArray<IFFmpegOutputComplexFilterArgument>.Builder complexFilters = ImmutableArray.CreateBuilder<IFFmpegOutputComplexFilterArgument>();
        private readonly ImmutableArray<IFFmpegOutputArgument>.Builder arguments = ImmutableArray.CreateBuilder<IFFmpegOutputArgument>();
        private readonly ImmutableArray<IFFmpegOutputVideoStreamBuilder>.Builder videoStreamBuilders = ImmutableArray.CreateBuilder<IFFmpegOutputVideoStreamBuilder>();
        private readonly ImmutableArray<IFFmpegOutputAudioStreamBuilder>.Builder audioStreamBuilders = ImmutableArray.CreateBuilder<IFFmpegOutputAudioStreamBuilder>();

        public IFFmpegOutputBuilder AddComplexFilter(Action<IFFmpegOutputComplexFilterBuilder> config)
        {
            var builder = new ComplexFilterBuilder();
            config.Invoke(builder);
            complexFilters.Add(builder.Build());
            return this;
        }

        public IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterArgument> factory)
        {
            var builder = new ComplexFilterBuilder();
            var argument = factory(builder);
            complexFilters.Add(argument);
            return this;
        }

        public IFFmpegOutputBuilder AddArgument(IFFmpegOutputArgument argument)
        {
            arguments.Add(argument ?? throw new ArgumentNullException(nameof(argument)));
            return this;
        }

        public IFFmpegOutputBuilder AddVideoStream(Action<IFFmpegOutputVideoStreamBuilder> config)
        {
            var builder = new VideoStreamBuilder(videoStreamBuilders.Count);
            config.Invoke(builder);
            videoStreamBuilders.Add(builder);
            return this;
        }

        public IFFmpegOutputBuilder AddAudioStream(Action<IFFmpegOutputAudioStreamBuilder> config)
        {
            var builder = new AudioStreamBuilder(audioStreamBuilders.Count);
            config.Invoke(builder);
            audioStreamBuilders.Add(builder);
            return this;
        }

        public IFFmpegOutput Build()
        {
            return new FFmpegOutput(Sink, complexFilters.ToImmutable(), arguments.ToImmutable(), videoStreamBuilders.ToImmutableArray(), audioStreamBuilders.ToImmutableArray());
        }
    }
}
