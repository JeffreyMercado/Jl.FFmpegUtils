using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    public record Builder(IFFmpegInputSource Source, IMediaInfo MediaInfo) : IFFmpegInputBuilder
    {
        public IList<IFFmpegInputArgument> Arguments { get; } = new List<IFFmpegInputArgument>();

        public IFFmpegInputBuilder AddArgument(IFFmpegInputArgument argument)
        {
            Arguments.Add(argument ?? throw new ArgumentNullException(nameof(argument)));
            return this;
        }

        public IFFmpegInput Build(int index)
        {
            return new FFmpegInput(Source, MediaInfo, index, Arguments.ToImmutableArray());
        }
    }
}
