namespace Jl.FFmpegUtils;

public interface ISubtitleStream : IMediaStream
{
    MediaStreamType IMediaStream.MediaType => MediaStreamType.Subtitle;

    int? Default { get; }
    int? Forced { get; }
    string? Language { get; }
    string? Title { get; }
}
