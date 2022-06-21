using System.Reflection;
using System.Text.RegularExpressions;

namespace Jl.FFmpegUtils;

internal static class Extensions
{
    private static readonly Regex re = new Regex(@"^\s*(?:([^""]+)|""((?:[^""]|\\"")+)"")\s*$", RegexOptions.Compiled);
    public static string TryQuoted(this string str)
    {
        var m = re.Match(str);
        if (!m.Success)
            throw new FormatException($"Invalid string");
        return re.Replace(str, m =>
        {
            var path = m.Groups[1].Success ? m.Groups[1].Value : m.Groups[2].Value;
            path = path.Replace("\"", "\\\"");
            return Regex.IsMatch(path, @"[ ""]") ? $"\"{path}\"" : path;
        });
    }

    public static string JoinString(this string separator, params object?[]? values) => JoinString(separator, values?.AsEnumerable());
    public static string JoinString(this string separator, IEnumerable<object?>? values) => string.Join(separator, values?.Where(x => x != null) ?? Enumerable.Empty<object>());

    public static TAttribute? GetCustomAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
    {
        var type = value.GetType();
        if (!Enum.IsDefined(type, value))
            return null;
        return type.GetField($"{value}")?.GetCustomAttribute<TAttribute>();
    }

    public static string? GetDescription(this Enum value)
    {
        var attr = value.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
        return attr?.Description;
    }
}
