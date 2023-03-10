using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSY.Products.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime ToBusinessDay(this DateTime date, int addDays, List<DateTime> holidays)
        {
            int day = 1;
            while (day <= addDays)
            {
                date = date.AddDays(1);
                if (date.DayOfWeek != DayOfWeek.Sunday && holidays.All(c => c.ToShortDateString() != date.ToShortDateString()))
                {
                    day++;
                }

            }
            return date;
        }
    }
}
