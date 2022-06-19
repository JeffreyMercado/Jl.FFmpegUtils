namespace Jl.FFmpegUtils;

public partial record FFmpegInput : IFFmpegInput
{
    private FFmpegInput(IFFmpegInputSource source, IMediaInfo mediaInfo, int index, IReadOnlyList<IFFmpegInputArgument> arguments) =>
        (Source, MediaStreams, Index, Arguments) = (source, new FFmpegInputMediaStreams(this, mediaInfo), index, arguments);
    public IFFmpegInputSource Source { get; }
    public IFFmpegInputMediaStreams MediaStreams { get; }
    public int Index { get; }
    public IReadOnlyList<IFFmpegInputArgument> Arguments { get; }

    public string SerializeInputArgument()
    {
        var arguments = Arguments.Select(x => x.SerializeInputArgument(this))
            .Append(Source.Serialize());
        return " ".JoinString(arguments);
    }

    public string SerializeInputArgumentReadable()
    {
        var arguments = new[]
        {
            Arguments.Select(x => x.SerializeInputArgument(this)),
        }
        .Where(x => x.Any())
        .Select(x => " ".JoinString(x))
        .Append(Source.Serialize());
        return "\\\n\t".JoinString(arguments);
    }
}
