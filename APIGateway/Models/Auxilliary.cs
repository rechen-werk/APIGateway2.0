using System;

namespace APIGateway.Models
{
    public static class Auxilliary
    {
        public static TimeSpan Millisecond(this double milliseconds) =>
            TimeSpan.FromMilliseconds(milliseconds);
        public static TimeSpan Milliseconds(this double milliseconds) =>
            TimeSpan.FromMilliseconds(milliseconds);
        public static TimeSpan Millisecond(this int milliseconds) =>
            TimeSpan.FromMilliseconds(milliseconds);
        public static TimeSpan Milliseconds(this int milliseconds) =>
            TimeSpan.FromMilliseconds(milliseconds);

        public static TimeSpan Second(this double seconds) =>
            TimeSpan.FromSeconds(seconds);
        public static TimeSpan Seconds(this double seconds) =>
            TimeSpan.FromSeconds(seconds);
        public static TimeSpan Second(this int seconds) =>
            TimeSpan.FromSeconds(seconds);
        public static TimeSpan Seconds(this int seconds) =>
            TimeSpan.FromSeconds(seconds);

        public static TimeSpan Minute(this double minutes) =>
            TimeSpan.FromMinutes(minutes);
        public static TimeSpan Minutes(this double minutes) =>
            TimeSpan.FromMinutes(minutes);
        public static TimeSpan Minute(this int minutes) =>
            TimeSpan.FromMinutes(minutes);
        public static TimeSpan Minutes(this int minutes) =>
            TimeSpan.FromMinutes(minutes);

        public static TimeSpan Hour(this double hours) =>
            TimeSpan.FromHours(hours);
        public static TimeSpan Hours(this double hours) =>
            TimeSpan.FromHours(hours);
        public static TimeSpan Hour(this int hours) =>
            TimeSpan.FromHours(hours);
        public static TimeSpan Hours(this int hours) =>
            TimeSpan.FromHours(hours);


        public static TimeSpan Day(this double days) =>
            TimeSpan.FromDays(days);
        public static TimeSpan Days(this double days) =>
            TimeSpan.FromDays(days);
        public static TimeSpan Day(this int days) =>
            TimeSpan.FromDays(days);
        public static TimeSpan Days(this int days) =>
            TimeSpan.FromDays(days);
    }

    public class Half
    {
        public const double A = 0.5d;
    }

    public class Quarter
    {
        public const double A = 0.25d;
    }
}