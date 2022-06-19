namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments(IReadOnlyList<IFFmpegGlobalArgument> Globals, IReadOnlyList<IFFmpegInput> Inputs, IFFmpegOutput Output) : IFFmpegClArguments
{
    public string SerializeArguments()
    {
        var arguments = Globals.Select(x => x.SerializeGlobalArgument())
            .Concat(Inputs.Select(x => x.SerializeInputArgument()))
            .Append(Output.SerializeOutputArgument());
        return " ".JoinString(arguments);
    }

    public string SerializeArgumentsReadable()
    {
        var arguments = new[]
        {
            Globals.Select(x => x.SerializeGlobalArgument()),
        }
        .Where(x => x.Any())
        .Select(x => " ".JoinString(x))
        .Concat(Inputs.Select(x => x.SerializeInputArgumentReadable()))
        .Append(Output.SerializeOutputArgumentReadable());
        return "\\\n".JoinString(arguments);
    }
}
