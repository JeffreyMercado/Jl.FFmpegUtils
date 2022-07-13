using System.Text.RegularExpressions;

namespace Jl.FFmpegUtils;

public class ConversionProgress : EventArgs
{
    internal static ConversionProgress? TryParse(string data, long? size, TimeSpan? duration)
    {
        //frame=98998 fps=102 q=28.0 size= 2456320kB time=00:55:01.19 bitrate=6095.4kbits/s dup=1 drop=0 speed= 3.4x
        if (!Regex.IsMatch(data, @"^frame=\s*[0-9.]+"))
            return null;
        var matches = Regex.Matches(data, @"(L)?([a-z0-9]+)=\s*(\S+)");
        var fields = matches.ToDictionary(m => m.Groups[2].Value, m => m.Groups[3].Value);
        var isLast = matches.Any(m => m.Groups[1].Success);
        return new ConversionProgress
        {
            IsLast = isLast,
            Frame = GetLong("frame"),
            Fps = GetDecimal("fps"),
            Q = GetDecimal("q"),
            Size = GetLong("size", ..^2) * 1024,
            Time = isLast ? duration : GetTimeSpan("time"),
            Bitrate = GetDecimal("bitrate", ..^7) * 1024,
            Dup = GetLong("dup"),
            Drop = GetLong("drop"),
            Speed = GetDecimal("speed", ..^1),
            InputSize = size,
            InputTime = duration,
        };

        long? GetLong(string name, Range? r = default) => fields.TryGetValue(name, out var v) && v != "N/A" && long.TryParse(Substring(v, r), out var vv) ? vv : null;
        decimal? GetDecimal(string name, Range? r = default) => fields.TryGetValue(name, out var v) && v != "N/A" && decimal.TryParse(Substring(v, r), out var vv) ? vv : null;
        TimeSpan? GetTimeSpan(string name) => fields.TryGetValue(name, out var v) && TimeSpan.TryParse(v, System.Globalization.CultureInfo.InvariantCulture, out var vv) ? vv : null;
        string Substring(string str, Range? r) => r != null ? str[r.Value] : str;
    }

    internal ConversionProgress()
    {
    }
    public bool IsLast { get; init; }
    public long? Frame { get; init; }
    public decimal? Fps { get; init; }
    public decimal? Q { get; init; }
    public long? Size { get; init; }
    public TimeSpan? Time { get; init; }
    public decimal? Bitrate { get; init; }
    public long? Dup { get; init; }
    public long? Drop { get; init; }
    public decimal? Speed { get; init; }
    public long? InputSize { get; init; }
    public TimeSpan? InputTime { get; init; }
    public double? Percent => Time?.TotalMilliseconds / InputTime?.TotalMilliseconds;
}
