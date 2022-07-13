namespace Jl.FFmpegUtils
{
    public interface IFFmpegConversionResult
    {
        IFFmpegClArguments Arguments { get; }
        IFFmpegOutputSink Output => Arguments.Output.Sink;
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        TimeSpan Duration => EndTime - StartTime;
        bool IsFinished { get; }
    }
}
