namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record AudioStreamBuilder(int Index) : IFFmpegOutputAudioStreamBuilder
        {
            public IList<IFFmpegOutputAudioStreamArgument> Arguments { get; } = new List<IFFmpegOutputAudioStreamArgument>();

            public IFFmpegOutputAudioStreamBuilder AddArgument(IFFmpegOutputAudioStreamArgument argument)
            {
                Arguments.Add(argument);
                return this;
            }

            public IEnumerable<IFFmpegOutputArgument> GetArguments()
            {
                foreach (var argument in Arguments)
                    yield return argument.Create(this);
            }
        }
    }
}
