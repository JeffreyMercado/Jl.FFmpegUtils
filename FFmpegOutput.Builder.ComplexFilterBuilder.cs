using System.Collections.Immutable;

namespace Jl.FFmpegUtils;

public partial record FFmpegOutput
{
    public partial record Builder
    {
        private record ComplexFilterBuilder() : IFFmpegOutputComplexFilterBuilder
        {
            public IList<string> Components { get; } = new List<string>();

            public IFFmpegOutputComplexFilterBuilder AddComponent(string component)
            {
                Components.Add(component);
                return this;
            }

            public IFFmpegOutputComplexFilterArgument Build()
            {
                return new ComplexFilter(Components.ToImmutableArray());
            }

            private record ComplexFilter(IReadOnlyList<string> Components) : IFFmpegOutputComplexFilterArgument
            {
                public string SerializeOutputArgument(IFFmpegOutput output) => $"-filter_complex {" ".JoinString(Components).TryQuoted()}";
            }
        }
    }
}
