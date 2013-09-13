using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

public static class StringExtension
{
    public static Boolean IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static bool IsMatch(this string str, string pattern)
    {
        if (pattern.IsNullOrEmpty())
            throw new ArgumentNullException("pattern");
        return Regex.IsMatch(str, pattern);
    }

#if NET35
        public static Boolean IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
#endif
}
