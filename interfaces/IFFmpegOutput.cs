namespace Jl.FFmpegUtils;

public interface IFFmpegOutput
{
    IFFmpegOutputSink Sink { get; }
    IReadOnlyList<IFFmpegOutputComplexFilterArgument> ComplexFilterArguments { get; }
    IReadOnlyList<IFFmpegOutputArgument> Arguments { get; }
    IReadOnlyList<IFFmpegOutputArgumentStream> VideoStreamArguments { get; }
    IReadOnlyList<IFFmpegOutputArgumentStream> AudioStreamArguments { get; }

    string SerializeOutputArgument();
    string SerializeOutputArgumentReadable();
}

public interface IFFmpegOutputBuilder
{
    IFFmpegOutputSink Sink { get; }
    IReadOnlyList<IFFmpegInput> Inputs { get; }
    IList<IFFmpegOutputComplexFilterArgument> ComplexFilters { get; }
    IList<IFFmpegOutputArgument> Arguments { get; }
    IList<IFFmpegOutputVideoStreamBuilder> VideoStreamBuilders { get; }
    IList<IFFmpegOutputAudioStreamBuilder> AudioStreamBuilders { get; }

    IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterBuilder> config);
    IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterArgument> factory);
    IFFmpegOutputBuilder AddArgument(IFFmpegOutputArgument argument);
    IFFmpegOutputBuilder AddVideoStream(Func<IFFmpegOutputVideoStreamBuilder, IFFmpegOutputVideoStreamBuilder> config);
    IFFmpegOutputBuilder AddAudioStream(Func<IFFmpegOutputAudioStreamBuilder, IFFmpegOutputAudioStreamBuilder> config);
    IFFmpegOutput Build();
}
