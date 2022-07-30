namespace Jl.FFmpegUtils;

public partial record FFmpegInput : IFFmpegInput
{
    public static IFFmpegInputBuilder CreateBuilder(IFFmpegInputSource source, IMediaInfo mediaInfo) => new Builder(
        source ?? throw new ArgumentNullException(nameof(source)),
        mediaInfo ?? throw new ArgumentNullException(nameof(mediaInfo))
    );

    private FFmpegInput(IFFmpegInputSource source, IMediaInfo mediaInfo, int index, IReadOnlyList<IFFmpegInputArgument> arguments)
    {
        Source = source;
        Duration = mediaInfo.Duration;
        Size = mediaInfo.Size;
        CreationTime = mediaInfo.CreationTime;
        MediaStreams = new FFmpegInputMediaStreams(this, mediaInfo);
        Index = index;
        Arguments = arguments;
    }
    public IFFmpegInputSource Source { get; }
    public TimeSpan Duration { get; }
    public long Size { get; }
    public DateTime? CreationTime { get; }
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
        return " \\\n\t".JoinString(serialized);
    }
}
