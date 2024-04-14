namespace CallForPapers.Application.Extensions;

public static class DateTimeExtensions
{
    public static bool IsMin(this DateTime time) => time == DateTime.MinValue;

    public static bool IsNotMin(this DateTime time) => !IsMin(time);
}