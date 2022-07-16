namespace Jl.FFmpegUtils
{
    public interface IFFmpegConversionResult
    {
        IFFmpegClArguments Arguments { get; }
        IEnumerable<IFFmpegOutputSink> Outputs => Arguments.Outputs.Select(x => x.Sink);
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        TimeSpan Duration => EndTime - StartTime;
        bool IsFinished { get; }
    }
}
