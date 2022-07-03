namespace Jl.FFmpegUtils
{
    public interface IConversionResult
    {
        DateTime StartTime { get; }
        DateTime EndTime { get; }
        TimeSpan Duration => EndTime - StartTime;
    }
}
