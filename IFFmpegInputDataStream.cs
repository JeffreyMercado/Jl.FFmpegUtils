namespace Jl.FFmpegUtils;

public interface IFFmpegInputDataStream : IFFmpegInputMediaStream
{
    IDataStream Stream { get; }
    int DataIndex { get; }
    string IFFmpegInputMediaStream.Identifier => $"{Input.Index}:{Stream.Index}";
}
