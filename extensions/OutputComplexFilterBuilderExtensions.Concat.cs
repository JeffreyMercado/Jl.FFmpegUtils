using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public static partial class OutputComplexFilterBuilderExtensions
{
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
    /// <summary>-filter_complex [concat spec]</summary>
    public static IFFmpegOutputComplexFilterArgument Concat(this IFFmpegOutputComplexFilterBuilder builder, string outputVideoName, string outputAudioName, params IFFmpegInput[] inputs)
    {
        return Concat(builder, outputVideoName, outputAudioName, inputs.Select(MakeSegment).ToArray());

        static (string, string) MakeSegment(IFFmpegInput input) =>
            ($"[{input.MediaStreams.VideoStreams.First().Identifier}]", $"[{input.MediaStreams.AudioStreams.First().Identifier}]");
    }
    public static IFFmpegOutputComplexFilterArgument Concat(this IFFmpegOutputComplexFilterBuilder builder, string outputVideoName, string outputAudioName, params (IFFmpegInputVideoStream, IFFmpegInputAudioStream)[] inputs)
    {
        return Concat(builder, outputVideoName, outputAudioName, inputs.Select(MakeSegment).ToArray());

        static (string, string) MakeSegment((IFFmpegInputVideoStream vid, IFFmpegInputAudioStream aud) segment) =>
            ($"[{segment.vid.Identifier}]", $"[{segment.aud.Identifier}]");
    }
    /// <summary>-filter_complex [concat spec]</summary>
    public static IFFmpegOutputComplexFilterArgument Concat(this IFFmpegOutputComplexFilterBuilder _, string outputVideoName, string outputAudioName, params (string, string)[] segments)
    {
        var outputNames = (outputVideoName, outputAudioName);
        return ComplexFilter(new ConcatComplexFilter(segments.ToImmutableArray(), outputNames));
    }
}
