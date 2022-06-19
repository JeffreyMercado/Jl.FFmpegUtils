namespace Jl.FFmpegUtils;

public interface IMediaInfo
{
    IMediaSource Source { get; }
    TimeSpan Duration { get; }
    long Size { get; }
    DateTime? CreationTime { get; }
    IReadOnlyList<IMediaStream> Streams { get; }
    IReadOnlyList<IVideoStream> VideoStreams { get; }
    IReadOnlyList<IAudioStream> AudioStreams { get; }
    IReadOnlyList<ISubtitleStream> SubtitleStreams { get; }
}
