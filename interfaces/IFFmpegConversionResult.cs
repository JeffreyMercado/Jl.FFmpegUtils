namespace Jl.FFmpegUtils
{
    public interface IFFmpegConversionResult
    {
        IFFmpegClArguments Arguments { get; }
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        TimeSpan Duration => EndTime - StartTime;
    }
}
