using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder(IFFmpegOutputSink Sink, IReadOnlyList<IFFmpegInput> Inputs) : IFFmpegOutputBuilder
    {
        public IList<IFFmpegOutputComplexFilterArgument> ComplexFilters { get; } = new List<IFFmpegOutputComplexFilterArgument>();
        public IList<IFFmpegOutputArgument> Arguments { get; } = new List<IFFmpegOutputArgument>();
        public IList<IFFmpegOutputVideoStreamBuilder> VideoStreamBuilders { get; } = new List<IFFmpegOutputVideoStreamBuilder>();
        public IList<IFFmpegOutputAudioStreamBuilder> AudioStreamBuilders { get; } = new List<IFFmpegOutputAudioStreamBuilder>();

        public IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterBuilder> config)
        {
            var builder = new ComplexFilterBuilder();
            config.Invoke(builder);
            ComplexFilters.Add(builder.Build());
            return this;
        }

        public IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterArgument> factory)
        {
            var builder = new ComplexFilterBuilder();
            var argument = factory(builder);
            ComplexFilters.Add(argument);
            return this;
        }

        public IFFmpegOutputBuilder AddArgument(IFFmpegOutputArgument argument)
        {
            Arguments.Add(argument ?? throw new ArgumentNullException(nameof(argument)));
            return this;
        }

        public IFFmpegOutputBuilder AddVideoStream(Func<IFFmpegOutputVideoStreamBuilder, IFFmpegOutputVideoStreamBuilder> config)
        {
            var builder = new VideoStreamBuilder(VideoStreamBuilders.Count);
            config.Invoke(builder);
            VideoStreamBuilders.Add(builder);
            return this;
        }

        public IFFmpegOutputBuilder AddAudioStream(Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder> config)
        {
            var builder = new AudioStreamBuilder(AudioStreamBuilders.Count);
            config.Invoke(builder);
            AudioStreamBuilders.Add(builder);
            return this;
        }

        public IFFmpegOutput Build()
        {
            return new FFmpegOutput(Sink, ComplexFilters.ToImmutableArray(), Arguments.ToImmutableArray(), VideoStreamBuilders.ToImmutableArray(), AudioStreamBuilders.ToImmutableArray());
        }
    }
}
