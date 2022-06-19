namespace Jl.FFmpegUtils;

public interface IDataStream : IMediaStream
{
    MediaStreamType IMediaStream.Type => MediaStreamType.Data;
}
