namespace Jl.FFmpegUtils;

public interface IFFmpegOutputAudioStreamArgument
{
    IFFmpegOutputArgument Create(IFFmpegOutputAudioStreamBuilder builder);
}

public interface IFFmpegOutputAudioStreamBuilder : IFFmpegOutputStreamBuilder
{
    IList<IFFmpegOutputAudioStreamArgument> Arguments { get; }

    IFFmpegOutputAudioStreamBuilder AddArgument(IFFmpegOutputAudioStreamArgument argument);
}
