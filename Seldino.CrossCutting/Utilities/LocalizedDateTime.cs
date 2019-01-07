using System;
using System.Collections.Generic;

namespace Seldino.CrossCutting.Utilities
{

    public struct LocalizedDateTime
    {
        internal DateTime PrimitiveDateTime { get; set; }

        public static LocalizedDateTime Now
        {
            get
            {
                var daylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(DateTime.UtcNow.Year);
                return DateTime.UtcNow.Add(daylightTime.Delta);
            }
        }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return PrimitiveDateTime.DayOfWeek;
            }
        }

        public static implicit operator LocalizedDateTime(DateTime dateTime)
        {
            return new LocalizedDateTime { PrimitiveDateTime = dateTime };
        }

        public static implicit operator DateTime(LocalizedDateTime dateTime)
        {
            return dateTime.PrimitiveDateTime;
        }

        public static bool operator ==(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a == b;
            return func(date1, date2);
        }

        public static bool operator !=(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a != b;
            return func(date1, date2);
        }

        public static bool operator <(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a < b;
            return func(date1, date2);
        }

        public static bool operator <=(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a <= b;
            return func(date1, date2);
        }

        public static bool operator >(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a > b;
            return func(date1, date2);
        }

        public static bool operator >=(LocalizedDateTime date1, LocalizedDateTime date2)
        {
            Func<DateTime, DateTime, bool> func = (a, b) => a >= b;
            return func(date1, date2);
        }

        public LocalizedDateTime AddYears(int value)
        {
            return PrimitiveDateTime.AddYears(value);
        }

        public LocalizedDateTime AddMonths(int value)
        {
            return PrimitiveDateTime.AddMonths(value);
        }

        public LocalizedDateTime AddDays(int value)
        {
            return PrimitiveDateTime.AddDays(value);
        }

        public LocalizedDateTime AddHours(int value)
        {
            return PrimitiveDateTime.AddHours(value);
        }

        public LocalizedDateTime AddMinutes(int value)
        {
            return PrimitiveDateTime.AddMinutes(value);
        }
      
        public LocalizedDateTime TruncateTime()
        {
            return PrimitiveDateTime.Subtract(PrimitiveDateTime.TimeOfDay);
        }

        public bool Equals(LocalizedDateTime other)
        {
            return PrimitiveDateTime.Equals(other.PrimitiveDateTime);
        }

        public override bool Equals(object obj)
        {
            return obj is LocalizedDateTime && Equals((LocalizedDateTime)obj);
        }

        public override int GetHashCode()
        {
            return PrimitiveDateTime.GetHashCode();
        }
    }

    public interface IDateTimeProviderResolver
    {
        IDateProvider ResolveDateProvider();

        ITimeProvider ResolveTimeProvider();
    }

    public interface ITimeProvider : ILocalizedValueProvider<TimeSpan>
    {
    }

    public interface ILocalizedValueProvider<T> where T : struct
    {
        T Parse(string value);

        string ToString(T value);

        string ToString(T value, string format);
    }

    public interface IDateProvider : ILocalizedValueProvider<DateTime>
    {
        IEnumerable<string> Months { get; }

        IEnumerable<string> DaysOfWeek { get; }

        DayOfWeek FirstDayOfWeek { get; }

        int GetDay(DateTime date);

        int GetMonth(DateTime date);

        int GetYear(DateTime date);

        DateTime GetDateTime(int year, int month, int day);

        DateTime AddYears(DateTime date, int value);

        DateTime AddMonths(DateTime date, int value);

        IEnumerable<Tuple<DateTime, DateTime>> GetMonthRange(int year);

        DateTime GetLastDayOfMonth(int year, int month);

        string ToShortDateString(DateTime value, string format);

        string ToLongDateString(DateTime value);

        string ToShortDateTimeString(DateTime value, string dateFormat, string timeFormat);

        string ToLongDateTimeString(DateTime value, string timeFormat);

        string ToTimeString(DateTime value, string format);
    }
}
