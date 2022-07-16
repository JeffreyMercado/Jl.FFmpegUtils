namespace Jl.FFmpegUtils.Arguments;

public record ConcatComplexFilter(IReadOnlyList<(string vid, string aud)> Segments, (string vid, string aud) OutputName) : ISimpleArgument
{
    public string Serialize()
    {
        var components = new List<string>();
        foreach (var segment in Segments)
            AddSegment(segment);
        var n = Segments.Count;
        components.Add($"concat=n={n}:v=1:a=1");
        components.Add(OutputName.vid);
        components.Add(OutputName.aud);
        return " ".JoinString(components);

        void AddSegment((string vid, string aud) segment)
        {
            components.Add(segment.vid);
            components.Add(segment.aud);
        }
    }
}
