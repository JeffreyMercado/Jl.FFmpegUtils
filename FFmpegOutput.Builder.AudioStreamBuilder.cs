namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record AudioStreamBuilder(int Index) : IFFmpegOutputAudioStreamBuilder
        {
            private readonly List<IFFmpegOutputAudioStreamArgument> arguments = new List<IFFmpegOutputAudioStreamArgument>();

            public IFFmpegOutputAudioStreamBuilder AddArgument(IFFmpegOutputAudioStreamArgument argument)
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
