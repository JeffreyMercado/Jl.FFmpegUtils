namespace Jl.FFmpegUtils;

public partial record FFmpegOutput(
    IFFmpegOutputSink Sink,
    IReadOnlyList<IFFmpegOutputComplexFilterArgument> ComplexFilterArguments,
    IReadOnlyList<IFFmpegOutputArgument> Arguments,
    IReadOnlyList<IFFmpegOutputArgumentStream> VideoStreamArguments,
    IReadOnlyList<IFFmpegOutputArgumentStream> AudioStreamArguments
) : IFFmpegOutput
{
    public static IFFmpegOutputBuilder CreateBuilder(IFFmpegOutputSink sink, IReadOnlyList<IFFmpegInput> inputs) => new Builder(
        sink ?? throw new ArgumentNullException(nameof(sink)),
        inputs ?? throw new ArgumentNullException(nameof(inputs))
    );

    public string SerializeOutputArgument()
    {
        var arguments = ComplexFilterArguments
            .Concat(Arguments)
            .Concat(VideoStreamArguments.SelectMany(x => x.GetArguments()))
            .Concat(AudioStreamArguments.SelectMany(x => x.GetArguments()));
        var serialized = arguments
            .Select(x => x.SerializeOutputArgument(this))
            .Append(Sink.Serialize());
        return " ".JoinString(serialized);
    }

    public string SerializeOutputArgumentReadable()
    {
        var argumentGroups = new[]
            {
                ComplexFilterArguments,
                Arguments,
                VideoStreamArguments.SelectMany(x => x.GetArguments()),
                AudioStreamArguments.SelectMany(x => x.GetArguments()),
            }.Where(x => x.Any());
        var serialized = argumentGroups
            .Select(x => " ".JoinString(x.Select(y => y.SerializeOutputArgument(this))))
            .Append(Sink.Serialize());
        return " \\\n\t".JoinString(serialized);
    }
}
