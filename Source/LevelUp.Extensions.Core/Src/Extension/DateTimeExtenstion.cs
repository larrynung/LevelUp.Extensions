using System;
using System.Globalization;

public static class DateTimeExtenstion
{
    public static string ToISO8601ShortString(this DateTime time)
    {
        return string.Concat(time.ToUniversalTime().ToString("s", CultureInfo.InvariantCulture), "Z");
    }

    public static string ToISO8601LongString(this DateTime time)
    {
        return time.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture);
    }
}
