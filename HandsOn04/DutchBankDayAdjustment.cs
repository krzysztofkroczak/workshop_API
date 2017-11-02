using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn04
{
    public class DutchBankDayAdjustment : IDateTimeOffsetAdjustment
    {
        public DateTimeOffset Adjust(DateTimeOffset value)
        {
            var candidate = value;
            while (!(IsDutchBankDay(candidate.DateTime)))
                candidate = candidate.AddDays(-1);
            return candidate;
        }

        private static bool IsDutchBankDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday)
                return false;
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return false;
            if (dutchHolidays.Contains(date.Date))
                return false;
            return true;
        }

        #region Dutch holidays
        private static DateTime[] dutchHolidays =
        {
            new DateTime(2017,  1,  1), // New Year's Day/Nieuwjaarsdag
            new DateTime(2017,  4, 14), // Good Friday/Goede Vrijdag
            new DateTime(2017,  4, 17), // Easter Monday/ Pasen
            new DateTime(2017,  4, 27), // King's Day/Koningsdag
            new DateTime(2017,  5,  5), // Liberation Day/Bevrijdingsdag
            new DateTime(2017,  5, 25), // Ascension Day/Hemelvaartsdag
            new DateTime(2017,  6,  5), // Whit Monday/Pinksteren
            new DateTime(2017, 12, 25), // Christmas Day/Eerste kerstdag
            new DateTime(2017, 12, 26), // St. Stephen's Day/Tweede kerstdag
            new DateTime(2018,  1,  1), // New Year's Day/Nieuwjaarsdag
            new DateTime(2018,  3, 30), // Good Friday/Goede Vrijdag
            // Lots and lots of dates...
            new DateTime(9999,  5,  6), // Ascension Day/Hemelvaartsdag
            new DateTime(9999,  5, 17), // Whit Monday/Pinksteren
            new DateTime(9999, 12, 25), // Christmas Day/Eerste kerstdag
            new DateTime(9999, 12, 26), // St. Stephen's Day/Tweede kerstdag
        };
        #endregion
    }
}
