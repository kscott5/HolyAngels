using System;

namespace HolyAngels.Extensions 
{
    public static class DateTimeExtensions {
        /// <summary>
        /// Changes the time to 12:00:00 AM
        /// </summary>
        /// <param name="datetime">Current date time</param>
        /// <returns>new date time value</returns>
        public static DateTime StartOfDay(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 0, 0, 0);
        }

        /// <summary>
        /// Returns the first day of the month to mm/01/yyyy 12:00:00 AM
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime StartOfMonth(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Returns the last day of the month to mm/31/yyyy 11:59:59 PM
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime datetime)
        {
            int days = DateTime.DaysInMonth(datetime.Year, datetime.Month);
            return new DateTime(datetime.Year, datetime.Month, days, 23, 59, 59);
        }

        /// <summary>
        /// Changes the time to 11:59:59 PM
        /// </summary>
        /// <param name="datetime">Current date time</param>
        /// <returns>new date time value</returns>
        public static DateTime EndOfDay(this DateTime datetime)
        {
            return new DateTime(datetime.Year, datetime.Month, datetime.Day, 23, 59, 59);
        }
    }
}