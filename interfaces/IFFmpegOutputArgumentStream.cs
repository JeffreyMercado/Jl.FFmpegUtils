namespace Jl.FFmpegUtils;

public interface IFFmpegOutputArgumentStream : IEnumerable<IFFmpegOutputArgument>
{
    IEnumerable<IFFmpegOutputArgument> GetArguments();
    IEnumerator<IFFmpegOutputArgument> IEnumerable<IFFmpegOutputArgument>.GetEnumerator() => GetArguments().GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable<IFFmpegOutputArgument>)this).GetEnumerator();
}

public interface IFFmpegOutputStreamBuilder : IFFmpegOutputArgumentStream
{
    int Index { get; }
}
