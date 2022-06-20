namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments(IReadOnlyList<IFFmpegGlobalArgument> Globals, IReadOnlyList<IFFmpegInput> Inputs, IFFmpegOutput Output) : IFFmpegClArguments
{
    public static IFFmpegClArgumentsBuilder CreateBuilder(IMediaInfoProvider provider) => new Builder(
        provider ?? throw new ArgumentNullException(nameof(provider))
    );


    public string SerializeArguments()
    {
        var serialized = Globals.Select(x => x.SerializeGlobalArgument())
            .Concat(Inputs.Select(x => x.SerializeInputArgument()))
            .Append(Output.SerializeOutputArgument());
        return " ".JoinString(serialized);
    }

    public string SerializeArgumentsReadable()
    {
        var argumentGroups = new[]
            {
                Globals,
            }
            .Where(x => x.Any());
        var serialized = argumentGroups
            .Select(x => " ".JoinString(x.Select(x => x.SerializeGlobalArgument())))
            .Concat(Inputs.Select(x => x.SerializeInputArgumentReadable()))
            .Append(Output.SerializeOutputArgumentReadable());
        return "\\\n".JoinString(serialized);
    }
}
