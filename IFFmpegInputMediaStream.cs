namespace Jl.FFmpegUtils;

public interface IFFmpegInputMediaStream
{
    IFFmpegInput Input { get; }
    int Index { get; }
    string Identifier => $"{Input.Identifier}:{Index}";
}
