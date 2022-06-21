namespace Jl.FFmpegUtils;

public interface IFFmpegInputMediaStream
{
    IFFmpegInput Input { get; }
    MediaStreamType Type => MediaStreamType.Unknown;
    int Index { get; }
    string Identifier => $"{Input.Identifier}:{Index}";
}
