namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record VideoStreamBuilder(int Index) : IFFmpegOutputVideoStreamBuilder
        {
            public IList<IFFmpegOutputVideoStreamArgument> Arguments { get; } = new List<IFFmpegOutputVideoStreamArgument>();

            public IFFmpegOutputVideoStreamBuilder AddArgument(IFFmpegOutputVideoStreamArgument argument)
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
