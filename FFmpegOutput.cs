namespace Jl.FFmpegUtils;

public partial record FFmpegOutput(
    IFFmpegOutputSink Sink,
    IReadOnlyList<IFFmpegOutputComplexFilterArgument> ComplexFilterArguments,
    IReadOnlyList<IFFmpegOutputArgument> Arguments,
    IReadOnlyList<IFFmpegOutputArgumentStream> VideoStreamArguments,
    IReadOnlyList<IFFmpegOutputArgumentStream> AudioStreamArguments
) : IFFmpegOutput
{
    public string SerializeOutputArgument()
    {
        var arguments = ((IFFmpegOutput)this).AllArguments.Select(x => x.SerializeOutputArgument(this))
            .Append(Sink.Serialize());
        return " ".JoinString(arguments);
    }

    public string SerializeOutputArgumentReadable()
    {
        var arguments = new[]
        {
            ComplexFilterArguments,
            Arguments,
            VideoStreamArguments.SelectMany(x => x.GetArguments()),
            AudioStreamArguments.SelectMany(x => x.GetArguments()),
        }
        .Where(x => x.Any())
        .Select(x => " ".JoinString(x.Select(y => y.SerializeOutputArgument(this))))
        .Append(Sink.Serialize());
        return "\\\n\t".JoinString(arguments);
    }
}
