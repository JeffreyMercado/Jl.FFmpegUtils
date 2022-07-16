using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

using Arguments;

public static partial class OutputComplexFilterBuilderExtensions
{
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
