namespace Jl.FFmpegUtils;

public partial record FFmpegClArguments(IReadOnlyList<IFFmpegGlobalArgument> Globals, IReadOnlyList<IFFmpegInput> Inputs, IReadOnlyList<IFFmpegOutput> Outputs) : IFFmpegClArguments
{
    public static IFFmpegClArgumentsBuilder CreateBuilder(IFFmpegProvider provider) => new Builder(
        provider ?? throw new ArgumentNullException(nameof(provider))
    );


    public string SerializeArguments()
    {
        var serialized = Globals.Select(x => x.SerializeGlobalArgument())
            .Concat(Inputs.Select(x => x.SerializeInputArgument()))
            .Concat(Outputs.Select(x => x.SerializeOutputArgument()));
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
            .Concat(Outputs.Select(x => x.SerializeOutputArgumentReadable()));
        return " \\\n".JoinString(serialized);
    }

    public IFFmpegConversion CreateConversion()
    {
        return new FFmpegConversion(this);
    }
}
