namespace Jl.FFmpegUtils;

public interface ISimpleArgument
{
    string Serialize();
}

public interface ISimpleArgument<T> : ISimpleArgument
{
    T Value { get; }

    string SerializeValue();
}
