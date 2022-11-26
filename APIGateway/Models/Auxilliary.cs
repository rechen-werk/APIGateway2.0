using System;

namespace APIGateway.Models
{
    public static class Auxilliary
    {
        public static TimeSpan Millisecond(this double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Second(this double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Minute(this double minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hour(this double hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Day(this double days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Milliseconds(this double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Seconds(this double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Minutes(this double minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hours(this double hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Days(this double days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Millisecond(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Second(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Minute(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hour(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Day(this int days)
        {
            return TimeSpan.FromDays(days);
        }

        public static TimeSpan Milliseconds(this int milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds);
        }

        public static TimeSpan Seconds(this int seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }

        public static TimeSpan Minutes(this int minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        public static TimeSpan Hours(this int hours)
        {
            return TimeSpan.FromHours(hours);
        }

        public static TimeSpan Days(this int days)
        {
            return TimeSpan.FromDays(days);
        }
    }

    public class Half
    {
        public static double A = 0.5d;
    }

    public class Quarter
    {
        public static double A = 0.25d;
    }
}