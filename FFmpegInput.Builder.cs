using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    public record Builder(IFFmpegInputSource Source, IMediaInfo MediaInfo) : IFFmpegInputBuilder
    {
        public static IFFmpegInputBuilder Create(IFFmpegInputSource source, IMediaInfo mediaInfo) => new Builder(
            source ?? throw new ArgumentNullException(nameof(source)),
            mediaInfo ?? throw new ArgumentNullException(nameof(mediaInfo))
        );

        private readonly ImmutableArray<IFFmpegInputArgument>.Builder arguments = ImmutableArray.CreateBuilder<IFFmpegInputArgument>();

        public IFFmpegInputBuilder AddArgument(IFFmpegInputArgument argument)
        {
            arguments.Add(argument ?? throw new ArgumentNullException(nameof(argument)));
            return this;
        }

        public IFFmpegInput Build(int index)
        {
            return new FFmpegInput(Source, MediaInfo, index, arguments.ToImmutable());
        }
    }
}
