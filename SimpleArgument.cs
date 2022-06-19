namespace Jl.FFmpegUtils;

internal abstract record SimpleArgument(string Flag, int? StreamIndex = default) : ISimpleArgument
{
    public virtual string GetIndexedValue(string value) => ":".JoinString(value, StreamIndex);
    public virtual string Serialize() => GetIndexedValue(Flag);
}

internal abstract record SimpleArgument<T>(string Flag, T Value, int? StreamIndex = default) : SimpleArgument(Flag, StreamIndex), ISimpleArgument<T>
{
    public override string Serialize() => " ".JoinString(base.Serialize(), SerializeValue().TryQuoted());
    public virtual string SerializeValue() => Value switch
    {
        ISimpleArgument s => s.Serialize(),
        Enum e => e.GetDescription(),
        _ => $"{Value}",
    };
}
