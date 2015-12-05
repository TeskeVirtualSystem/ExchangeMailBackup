using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange_Manager
{
    public class ScheduledDateTime
    {
        public int hour, minute, dayofweek, dayofmonth, month;

        public ScheduledDateTime()
        {
            this.hour = -1;
            this.minute = -1;
            this.dayofweek = -1;
            this.dayofmonth = -1;
            this.month = -1;
        }
        public ScheduledDateTime(String hour, String minute, String dayofweek, String dayofmonth, String month)
        {
            this.hour           = (hour.Contains("*"))          ? -1 : Int32.Parse(hour);
            this.minute         = (minute.Contains("*"))        ? -1 : Int32.Parse(minute);
            this.dayofweek      = (dayofweek.Contains("*"))     ? -1 : Int32.Parse(dayofweek);
            this.dayofmonth     = (dayofmonth.Contains("*"))    ? -1 : Int32.Parse(dayofmonth);
            this.month          = (month.Contains("*"))         ? -1 : Int32.Parse(month);

            this.hour = (this.hour > 23) ? -1 : this.hour;
            this.minute = (this.minute > 59) ? -1 : this.minute;
            this.dayofweek = (this.dayofweek > 6) ? -1 : this.dayofweek;
            this.dayofmonth = (this.dayofmonth > 31 | this.dayofmonth < 1) ? -1 : this.dayofmonth;
            this.month = (this.month > 12 | this.month < 1) ? -1 : this.month;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + hour ^ minute + dayofweek ^ dayofmonth + month ^ base.GetHashCode();
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
                return false;

            ScheduledDateTime a = obj as ScheduledDateTime;
            if ((System.Object)a == null)
                return false;

            bool equals = true;
            if (a.hour != -1 && hour != -1)
                equals &= a.hour == hour;
            if (a.minute != -1 && minute != -1)
                equals &= a.minute == minute;
            if (a.dayofweek != -1 && dayofweek != -1)
                equals &= a.dayofweek == dayofweek;
            if (a.dayofmonth != -1 && dayofmonth != -1)
                equals &= a.dayofmonth == dayofmonth;
            if (a.month != -1 && month != -1)
                equals &= a.month == month;

            return equals;
        }
        public static bool operator ==(ScheduledDateTime a, ScheduledDateTime b)
        {
            if (a == null || b == null)
                return false;
            bool equals = true;
            if (a.hour != -1 && b.hour != -1)
                equals &= a.hour == b.hour;
            if (a.minute != -1 && b.minute != -1)
                equals &= a.minute == b.minute;
            if (a.dayofweek != -1 && b.dayofweek != -1)
                equals &= a.dayofweek == b.dayofweek;
            if (a.dayofmonth != -1 && b.dayofmonth != -1)
                equals &= a.dayofmonth == b.dayofmonth;
            if (a.month != -1 && b.month != -1)
                equals &= a.month == b.month;

            return equals;
        }
        public static bool operator !=(ScheduledDateTime a, ScheduledDateTime b)
        {
            if (a == null || b == null)
                return true;
            bool equals = true;
            if (a.hour != -1 && b.hour != -1)
                equals &= a.hour == b.hour;
            if (a.minute != -1 && b.minute != -1)
                equals &= a.minute == b.minute;
            if (a.dayofweek != -1 && b.dayofweek != -1)
                equals &= a.dayofweek == b.dayofweek;
            if (a.dayofmonth != -1 && b.dayofmonth != -1)
                equals &= a.dayofmonth == b.dayofmonth;
            if (a.month != -1 && b.month != -1)
                equals &= a.month == b.month;

            return !equals;
        }
        public bool isOnDate(DateTime dt)    {
            bool equals = true;
            if (hour != -1)
                equals &= hour == dt.Hour;
            if (minute != -1)
                equals &= minute == dt.Minute;
            if (dayofweek != -1)
                equals &= dayofweek == (int) dt.DayOfWeek;
            if (dayofmonth != -1)
                equals &= dayofmonth == dt.Day;
            if (month != -1)
                equals &= month == dt.Month;
            return equals;
        }
        public String toString()
        {
            return hour + " " + minute + " " + dayofweek + " " + dayofmonth + " " + month;
        }
    }
}
