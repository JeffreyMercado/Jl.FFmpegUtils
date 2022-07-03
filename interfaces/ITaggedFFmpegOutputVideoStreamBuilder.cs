namespace Jl.FFmpegUtils;

public interface ITaggedFFmpegOutputVideoStreamBuilder : IFFmpegOutputVideoStreamBuilder
{
    IFFmpegOutputVideoStreamBuilder Builder { get; }

    IEnumerable<IFFmpegOutputArgument> IFFmpegOutputArgumentStream.GetArguments() => Builder.GetArguments();
    IEnumerator<IFFmpegOutputArgument> IEnumerable<IFFmpegOutputArgument>.GetEnumerator() => GetArguments().GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable<IFFmpegOutputArgument>)this).GetEnumerator();
    IList<IFFmpegOutputVideoStreamArgument> IFFmpegOutputVideoStreamBuilder.Arguments => Builder.Arguments;
    int IFFmpegOutputStreamBuilder.Index => Builder.Index;
    IFFmpegOutputVideoStreamBuilder IFFmpegOutputVideoStreamBuilder.AddArgument(IFFmpegOutputVideoStreamArgument argument) => Builder.AddArgument(argument);
}

public interface IFFmpegOutputVideoStreamArgument<T> : IFFmpegOutputVideoStreamArgument
    where T : ILibTag
{
}

public interface IFFmpegOutputVideoStreamBuilder<T> : ITaggedFFmpegOutputVideoStreamBuilder
    where T : ILibTag
{
    IFFmpegOutputVideoStreamBuilder<T> AddArgument(IFFmpegOutputVideoStreamArgument<T> argument)
    {
        Builder.AddArgument(argument);
        return this;
    }
}
