using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    private partial class FFmpegInputMediaStreams : IFFmpegInputMediaStreams
    {
        private readonly IReadOnlyList<IFFmpegInputMediaStream> mediaStreams;
        public FFmpegInputMediaStreams(FFmpegInput input, IMediaInfo mediaInfo)
        {
            VideoStreams = mediaInfo.Streams.OfType<IVideoStream>()
                .Select((x, i) => new FFmpegInputVideoStream(input, x, i))
                .ToImmutableArray();
            AudioStreams = mediaInfo.Streams.OfType<IAudioStream>()
                .Select((x, i) => new FFmpegInputAudioStream(input, x, i))
                .ToImmutableArray();
            SubtitleStreams = mediaInfo.Streams.OfType<ISubtitleStream>()
                .Select((x, i) => new FFmpegInputSubtitleStream(input, x, i))
                .ToImmutableArray();
            DataStreams = mediaInfo.Streams.OfType<IDataStream>()
                .Select((x, i) => new FFmpegInputDataStream(input, x, i))
                .ToImmutableArray();
            mediaStreams = VideoStreams.Cast<IFFmpegInputMediaStream>()
                .Concat(AudioStreams)
                .Concat(SubtitleStreams)
                .Concat(DataStreams)
                .ToImmutableArray();
        }
        public IReadOnlyList<IFFmpegInputVideoStream> VideoStreams { get; }
        public IReadOnlyList<IFFmpegInputAudioStream> AudioStreams { get; }
        public IReadOnlyList<IFFmpegInputSubtitleStream> SubtitleStreams { get; }
        public IReadOnlyList<IFFmpegInputDataStream> DataStreams { get; }
        public int Count => mediaStreams.Count;
        public IFFmpegInputMediaStream this[int index] => mediaStreams[index];

        public IEnumerator<IFFmpegInputMediaStream> GetEnumerator() => mediaStreams.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
