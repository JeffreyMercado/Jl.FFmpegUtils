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

    IFFmpegOutputBuilder AddComplexFilter(Action<IFFmpegOutputComplexFilterBuilder> config);
    IFFmpegOutputBuilder AddComplexFilter(Func<IFFmpegOutputComplexFilterBuilder, IFFmpegOutputComplexFilterArgument> factory);
    IFFmpegOutputBuilder AddArgument(IFFmpegOutputArgument argument);
    IFFmpegOutputBuilder AddVideoStream(Action<IFFmpegOutputVideoStreamBuilder> config);
    IFFmpegOutputBuilder AddAudioStream(Action<IFFmpegOutputAudioStreamBuilder> config);
    IFFmpegOutput Build();
}
