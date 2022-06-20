using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private class FFmpegInputMediaStreams : IFFmpegInputMediaStreams
    {
        private readonly IReadOnlyList<IFFmpegInputMediaStream> mediaStreams;
        public FFmpegInputMediaStreams(FFmpegInput input, IMediaInfo mediaInfo)
        {
            mediaStreams = mediaInfo.Streams.Select(x => CreateStream(input, x)).ToImmutableArray();
            VideoStreams = mediaStreams.OfType<IFFmpegInputVideoStream>().ToImmutableArray();
            AudioStreams = mediaStreams.OfType<IFFmpegInputAudioStream>().ToImmutableArray();
            SubtitleStreams = mediaStreams.OfType<IFFmpegInputSubtitleStream>().ToImmutableArray();
        }
        public IReadOnlyList<IFFmpegInputVideoStream> VideoStreams { get; }
        public IReadOnlyList<IFFmpegInputAudioStream> AudioStreams { get; }
        public IReadOnlyList<IFFmpegInputSubtitleStream> SubtitleStreams { get; }
        public int Count => mediaStreams.Count;
        public IFFmpegInputMediaStream this[int index] => mediaStreams[index];

        public IEnumerator<IFFmpegInputMediaStream> GetEnumerator() => mediaStreams.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private static IFFmpegInputMediaStream CreateStream(FFmpegInput input, IMediaStream stream) => stream switch
    {
        IVideoStream vid => new FFmpegInputVideoStream(input, vid) as IFFmpegInputMediaStream,
        IAudioStream aud => new FFmpegInputAudioStream(input, aud),
        ISubtitleStream sub => new FFmpegInputSubtitleStream(input, sub),
        var str => new FFmpegInputNullStream(input, str),
    };

    private abstract record FFmpegInputMediaStream<T>(IFFmpegInput Input, T Stream) : IFFmpegInputMediaStream where T : IMediaStream
    {
        public int Index => Stream.Index;
    }

    private record FFmpegInputNullStream(IFFmpegInput Input, IMediaStream Stream) : FFmpegInputMediaStream<IMediaStream>(Input, Stream);
}
