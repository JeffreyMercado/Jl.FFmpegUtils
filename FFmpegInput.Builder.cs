using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegInput
{
    public record Builder(IFFmpegInputSource Source, IMediaInfo MediaInfo) : IFFmpegInputBuilder
    {
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
