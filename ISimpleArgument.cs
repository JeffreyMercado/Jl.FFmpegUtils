namespace Jl.FFmpegUtils;

internal interface ISimpleArgument
{
    string Serialize();
}

internal interface ISimpleArgument<T> : ISimpleArgument
{
    T Value { get; }

    string SerializeValue();
}
