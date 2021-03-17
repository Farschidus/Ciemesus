using System;
using System.Globalization;

namespace Farschidus
{
    /// <summary>
    /// Represent an instance of Persian date and time
    /// </summary>
    public class JalaliDateTime
    {
        #region "Properties"

        public string[] MonthNames = new string[12] { "فروردین","اردیبهشت", "خرداد",
                                         "تیر", "مرداد","شهریور",
                                         "مهر","آبان", "آذر",
                                         "دی", "بهمن","اسفند"};

        public string[] WeekDayNames = new string[7] { "یک‌شنبه", "دوشنبه",
                                         "سه‌شنبه", "چهارشنبه","پنج‌شنبه",
                                         "جمعه","شنبه"};

        public const string PM = "ب.ظ";
        public const string PM_SHORT = "ب";
        public const string AM = "ق.ظ";
        public const string AM_SHORT = "ق";

        private int _year;
        public int Year
        {
            get
            {
                return _year;
            }
            private set
            {
                _year = value;

            }
        }

        private int _month;
        public int Month
        {
            get
            {
                return _month;
            }
            private set
            {
                _month = value;

            }
        }

        private int _day;
        public int Day
        {
            get
            {
                return _day;
            }
            private set
            {
                _day = value;

            }
        }

        private int _hour;
        public int Hour
        {
            get
            {
                return _hour;
            }
            private set
            {
                _hour = value;

            }
        }

        private int _minute;
        public int Minute
        {
            get
            {
                return _minute;
            }
            private set
            {
                _minute = value;

            }
        }

        private int _second;
        public int Second
        {
            get
            {
                return _second;
            }
            private set
            {
                _second = value;

            }
        }

        private int _milliSecond;
        public int MilliSecond
        {
            get
            {
                return _milliSecond;
            }
            private set
            {
                _milliSecond = value;

            }
        }

        private DayOfWeek _dayOfTheWeek;
        public DayOfWeek DayOfTheWeek
        {
            get 
            {
                return _dayOfTheWeek;
            }
            private set 
            {
                _dayOfTheWeek = value;
            }
        }

        public TimeSliceEnum? TimeSlice
        {
            get
            {
                if ((this.Hour == 0 && this.Minute == 0) || (this.Hour == 12 && this.Minute == 0))
                {
                    return null;
                }
                if (this.Hour >= 0 && this.Hour < 12)
                {
                    return JalaliDateTime.TimeSliceEnum.AM;
                }
                return JalaliDateTime.TimeSliceEnum.PM;
            }
        }
        #endregion

        #region "Cunstructors"

        public JalaliDateTime()
        {
        }
        public JalaliDateTime(DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            this.Year = jc.GetYear(date);
            this.Month = jc.GetMonth(date);
            this.Day = jc.GetDayOfMonth(date);
            this.Hour = jc.GetHour(date);
            this.Minute = jc.GetMinute(date);
            this.Second = jc.GetSecond(date);
            this.MilliSecond = Convert.ToInt32(jc.GetMilliseconds(date));
            this.DayOfTheWeek = date.DayOfWeek;    
        }

        public JalaliDateTime(int year, byte month, byte day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }

        #endregion

        #region "Methods"

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2} {3}:{4}", this.Year, this.Month.ToString("0#"), this.Day.ToString("0#"), this.Hour.ToString("0#"), this.Minute.ToString("0#"));
        }

        public string ToString(string format)
        {
            if (format == "JD")
            {
                format = "w dd MMMM  yyyy";
            }

            if (format == "jd")
            {
                format = "dd MMMM  yyyy";
            }

            if (format == "JDT")
            {
                format="HH:mm w dd MMMM  yyyy";
            }
            if (format == "jdt")
            {
                format = "HH:mm dd MMMM  yyyy";
            }
            if (format.Contains("yyyy"))
            {
                format = format.Replace("yyyy", this.Year.ToString());
            }

            if (format.Contains("yy"))
            {
                format = format.Replace("yyyy", (this.Year % 100).ToString());
            }

            if (format.Contains("MMMM"))
            {
                format = format.Replace("MMMM", MonthNames[this.Month - 1]);
            }
            if (format.Contains("MM"))
            {
                format = format.Replace("MM", this.Month.ToString("0#"));
            }
            if (format.Contains("M"))
            {
                format = format.Replace("M", this.Month.ToString());
            }

            if (format.Contains("dd"))
            {
                format = format.Replace("dd", this.Day.ToString("0#"));
            }
            if (format.Contains("d"))
            {
                format = format.Replace("d", this.Day.ToString());
            }

            if (format.Contains("w"))
            {
                format = format.Replace("w", WeekDayNames[(byte)this.DayOfTheWeek]);
            }

            if (format.Contains("HH"))
            {
                format = format.Replace("HH", this.Hour.ToString("0#"));
            }
            if (format.Contains("H"))
            {
                format = format.Replace("H", this.Hour.ToString());
            }

            if (format.Contains("hh"))
            {
                format = format.Replace("hh", (this.Hour % 12).ToString("0#"));
            }
            if (format.Contains("h"))
            {
                format = format.Replace("h", (this.Hour % 12).ToString());
            }

            if (this.TimeSlice.HasValue)
            {
                if (format.Contains("tt"))
                {
                    format = format.Replace("tt", (this.TimeSlice == TimeSliceEnum.AM) ? AM : PM);
                }
                if (format.Contains("t"))
                {
                    format = format.Replace("t", (this.TimeSlice == TimeSliceEnum.AM) ? AM_SHORT : PM_SHORT);
                }
            }

            if (format.Contains("mm"))
            {
                format = format.Replace("mm", this.Minute.ToString("0#"));
            }
            if (format.Contains("m"))
            {
                format = format.Replace("m", this.Minute.ToString());
            }

            if (format.Contains("ss"))
            {
                format = format.Replace("ss", this.Second.ToString("0#"));
            }
            if (format.Contains("s"))
            {
                format = format.Replace("s", this.Second.ToString());
            }

            if (format.Contains("ms"))
            {
                format = format.Replace("ms", this.MilliSecond.ToString());
            }

            return format;
        }

        public string ToShortDateString()
        {
            return string.Format("{0}/{1}/{2}", this.Year, this.Month.ToString("0#"), this.Day.ToString("0#"));
        }
        public string ToShortDateString(string format)
        {
            if (format.Contains("yyyy"))
            {
                format = format.Replace("yyyy", this.Year.ToString());
            }

            if (format.Contains("MMMM"))
            {
                format = format.Replace("MMMM", MonthNames[this.Month - 1]);
            }
            if (format.Contains("MM"))
            {
                format = format.Replace("MM", this.Month.ToString("0#"));
            }
            if (format.Contains("M"))
            {
                format = format.Replace("M", this.Month.ToString());
            }

            if (format.Contains("dd"))
            {
                format = format.Replace("dd", this.Day.ToString("0#"));
            }
            if (format.Contains("d"))
            {
                format = format.Replace("d", this.Day.ToString());
            }

            return format;
        }
        public string ToShortTimeString()
        {
            return string.Format("{0}:{1}", this.Hour.ToString("0#"), this.Minute.ToString("0#"));
        }

        #endregion

        #region "Static Methods"

        public static bool GeiorgianDateIsValid(DateTime? d)
        {
            DateTime MinD = new DateTime(1753, 1, 1, 12, 0, 0);
            DateTime MaxD = new DateTime(9999, 12, 31, 11, 59, 59);
            if (d == null)
            {
                return false;
            }
            else
            {
                if ((d >= MinD) && (d <= MaxD))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static DateTime? ConvertToNullableGregorianDate(string s)
        {
            try
            {
                char[] delimit = new char[] { ' ', '/', '\\', '.', '-', '_', ':' };
                int[] part = new int[7];
                int i = 0;
                foreach (string substr in s.Split(delimit))
                {
                    part[i] = Convert.ToInt32(substr);
                    i++;
                }

                PersianCalendar jc = new PersianCalendar();
                System.DateTime d = jc.ToDateTime(part[0], part[1], part[2], part[3], part[4], part[5], part[6]);
                return d;
            }
            catch
            {
                return null;
            }
        }
        public static DateTime ConvertToGregorianDate(string s)
        {
            char[] delimit = new char[] { ' ', '/', '\\', '.', '-', '_', ':' };
            int[] part = new int[7];
            int i = 0;
            foreach (string substr in s.Split(delimit))
            {
                part[i] = Convert.ToInt32(substr);
                i++;
            }

            PersianCalendar jc = new PersianCalendar();
            DateTime d = jc.ToDateTime(part[0], part[1], part[2], part[3], part[4], part[5], part[6]);
            return d;
        }
        public static DateTime ConvertToGregorianDate(JalaliDateTime j)
        {
            PersianCalendar jc = new PersianCalendar();
            DateTime d = jc.ToDateTime(j.Year, j.Month, j.Day, j.Hour, j.Minute, j.Second, j.MilliSecond);
            return d;
        }

        public DateTime ToGregorianDate()
        {
            return ConvertToGregorianDate(this);
        }

        #endregion

        #region "Enum And Classes"

        public enum TimeSliceEnum
        {
            AM,
            PM
        }

        #endregion
    }
}
