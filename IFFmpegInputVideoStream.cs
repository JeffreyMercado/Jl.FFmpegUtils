namespace Jl.FFmpegUtils;

public interface IFFmpegInputVideoStream : IFFmpegInputMediaStream
{
    IVideoStream Stream { get; }
}
