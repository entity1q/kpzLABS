using System.Text.RegularExpressions;

namespace Decorator;

public static partial class StringExtensions
{
    public static string SplitPascalCase(this string str) => MyRegex().Replace(str, " $1");

    [GeneratedRegex("(\\B[A-Z])")]
    private static partial Regex MyRegex();
}