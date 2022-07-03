namespace Jl.FFmpegUtils;

public class ConversionData : EventArgs
{
    internal ConversionData(string data) => Data = data;

    public string Data { get; }
}
