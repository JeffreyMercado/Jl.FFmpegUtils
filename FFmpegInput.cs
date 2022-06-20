namespace Jl.FFmpegUtils;

public partial record FFmpegInput : IFFmpegInput
{
    public static IFFmpegInputBuilder CreateBuilder(IFFmpegInputSource source, IMediaInfo mediaInfo) => new Builder(
        source ?? throw new ArgumentNullException(nameof(source)),
        mediaInfo ?? throw new ArgumentNullException(nameof(mediaInfo))
    );

    private FFmpegInput(IFFmpegInputSource source, IMediaInfo mediaInfo, int index, IReadOnlyList<IFFmpegInputArgument> arguments) =>
        (Source, MediaStreams, Index, Arguments) = (source, new FFmpegInputMediaStreams(this, mediaInfo), index, arguments);
    public IFFmpegInputSource Source { get; }
    public IFFmpegInputMediaStreams MediaStreams { get; }
    public int Index { get; }
    public IReadOnlyList<IFFmpegInputArgument> Arguments { get; }

    public string SerializeInputArgument()
    {
        var serialized = Arguments.Select(x => x.SerializeInputArgument(this))
            .Append(Source.Serialize());
        return " ".JoinString(serialized);
    }

    public string SerializeInputArgumentReadable()
    {
        var argumentGroups = new[]
            {
                Arguments,
            }
            .Where(x => x.Any());
        var serialized = argumentGroups
            .Select(x => " ".JoinString(x.Select(x => x.SerializeInputArgument(this))))
            .Append(Source.Serialize());
        return "\\\n\t".JoinString(serialized);
    }
}
