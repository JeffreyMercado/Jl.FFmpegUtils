namespace Jl.FFmpegUtils;

public interface IFFmpegInputVideoStream : IFFmpegInputMediaStream
{
    IVideoStream Stream { get; }
    int VideoIndex { get; }
    string IFFmpegInputMediaStream.Identifier => $"{Input.Index}:{Stream.Index}";
}
