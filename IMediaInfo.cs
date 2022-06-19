namespace Jl.FFmpegUtils;

public interface IMediaInfo
{
    IMediaSource Source { get; }
    IReadOnlyList<IMediaStream> Streams { get; }
    IReadOnlyList<IVideoStream> VideoStreams { get; }
    IReadOnlyList<IAudioStream> AudioStreams { get; }
    IReadOnlyList<ISubtitleStream> SubtitleStreams { get; }
    IReadOnlyList<IDataStream> DataStreams { get; }
}
