using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record ComplexFilterBuilder() : IFFmpegOutputComplexFilterBuilder
        {
            private readonly ImmutableArray<string>.Builder componentParts = ImmutableArray.CreateBuilder<string>();

            public IFFmpegOutputComplexFilterBuilder AddComponent(string component)
            {
                componentParts.Add(component);
                return this;
            }

            public IFFmpegOutputComplexFilterArgument Build()
            {
                return new ComplexFilter(componentParts.ToImmutable());
            }

            private record ComplexFilter(IReadOnlyList<string> Components) : IFFmpegOutputComplexFilterArgument
            {
                public string SerializeOutputArgument(IFFmpegOutput output) => $"-filter_complex {" ".JoinString(Components).TryQuoted()}";
            }
        }
    }
}
