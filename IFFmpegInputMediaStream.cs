namespace Jl.FFmpegUtils;

public interface IFFmpegInputMediaStream
{
    IFFmpegInput Input { get; }
    string Identifier { get; }
}
