namespace Jl.FFmpegUtils;

public interface IFFmpegInputMediaStreams : IReadOnlyList<IFFmpegInputMediaStream>
{
    IReadOnlyList<IFFmpegInputVideoStream> VideoStreams { get; }
    IReadOnlyList<IFFmpegInputAudioStream> AudioStreams { get; }
    IReadOnlyList<IFFmpegInputSubtitleStream> SubtitleStreams { get; }
    IReadOnlyList<IFFmpegInputDataStream> DataStreams { get; }
}
