namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record VideoStreamBuilder(int Index) : IFFmpegOutputVideoStreamBuilder
        {
            private readonly List<IFFmpegOutputVideoStreamArgument> arguments = new List<IFFmpegOutputVideoStreamArgument>();

            public IFFmpegOutputVideoStreamBuilder AddArgument(IFFmpegOutputVideoStreamArgument argument)
            {
                arguments.Add(argument);
                return this;
            }

            public IEnumerable<IFFmpegOutputArgument> GetArguments()
            {
                foreach (var argument in arguments)
                    yield return argument.Create(this);
            }
        }
    }
}
