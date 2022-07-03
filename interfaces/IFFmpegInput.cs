namespace Jl.FFmpegUtils;

public interface IFFmpegInput
{
    IFFmpegInputSource Source { get; }
    long Size { get; }
    TimeSpan Duration { get; }
    DateTime? CreationTime { get; }
    IFFmpegInputMediaStreams MediaStreams { get; }
    int Index { get; }
    string Identifier => $"{Index}";
    IReadOnlyList<IFFmpegInputArgument> Arguments { get; }

    string SerializeInputArgument();
    string SerializeInputArgumentReadable();
}

public interface IFFmpegInputBuilder
{
    IFFmpegInputSource Source { get; }
    IMediaInfo MediaInfo { get; }
    IList<IFFmpegInputArgument> Arguments { get; }

    IFFmpegInputBuilder AddArgument(IFFmpegInputArgument argument);
    IFFmpegInput Build(int index);
}
