using System.Text.RegularExpressions;

namespace Utils;

public static class StringExtension
{
    public static bool IsSingleWord(this string s)
    {
        var pattern = @"[\d\W_]+";
        return !Regex.IsMatch(s, pattern);
    }
}
