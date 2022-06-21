namespace Jl.FFmpegUtils;

public record TaggedOutputVideoStreamBuilder<T>(IFFmpegOutputVideoStreamBuilder Builder) : IFFmpegOutputVideoStreamBuilder<T>
    where T : ILibTag;
