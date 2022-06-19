namespace Jl.FFmpegUtils;

public interface IAudioStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Audio;
    int SampleRate { get; }
    int Channels { get; }
    TimeSpan Duration { get; }
    long Bitrate { get; }

    int? Default { get; }
    int? Forced { get; }
    string? Language { get; }
    string? Title { get; }
}
