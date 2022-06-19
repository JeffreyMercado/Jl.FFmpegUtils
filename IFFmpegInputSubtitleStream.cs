namespace Jl.FFmpegUtils;

public interface IFFmpegInputSubtitleStream : IFFmpegInputMediaStream
{
    ISubtitleStream Stream { get; }
    int SubtitleIndex { get; }
    string IFFmpegInputMediaStream.Identifier => $"{Input.Index}:{Stream.Index}";
}
