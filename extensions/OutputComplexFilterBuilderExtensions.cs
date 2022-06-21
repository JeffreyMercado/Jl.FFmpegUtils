using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public static partial class OutputComplexFilterBuilderExtensions
{
    internal record ComplexFilterArgument<T>(T Value) : SimpleArgument<T>("-filter_complex", Value), ISimpleOutputComplexFilterArgument;
    private static ComplexFilterArgument<T> ComplexFilter<T>(T value) => new ComplexFilterArgument<T>(value);

    internal record ConcatComplexFilter(IReadOnlyList<(string vid, string aud)> Segments, (string vid, string aud) OutputName) : ISimpleArgument
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
    public static IFFmpegOutputComplexFilterArgument Concat(this IFFmpegOutputComplexFilterBuilder builder, string outputVideoName, string outputAudioName,
        (IFFmpegInputVideoStream, IFFmpegInputAudioStream) first, (IFFmpegInputVideoStream, IFFmpegInputAudioStream) second, params (IFFmpegInputVideoStream, IFFmpegInputAudioStream)[] rest)
    {
        return Concat(builder, outputVideoName, outputAudioName, MakeSegment(first), MakeSegment(second), rest.Select(MakeSegment).ToArray());

        (string, string) MakeSegment((IFFmpegInputVideoStream vid, IFFmpegInputAudioStream aud) segment) =>
            ($"[{segment.vid.Identifier}]", $"[{segment.aud.Identifier}]");
    }
    public static IFFmpegOutputComplexFilterArgument Concat(this IFFmpegOutputComplexFilterBuilder builder,
        string outputVideoName, string outputAudioName, (string, string) first, (string, string) second, params (string, string)[] rest)
    {
        var segments = new[] { first, second }.Concat(rest);
        var outputNames = (outputVideoName, outputAudioName);
        return ComplexFilter(new ConcatComplexFilter(segments.ToImmutableArray(), outputNames));
    }
}