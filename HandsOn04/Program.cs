using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn04
{
    class Program
    {
        static void Main(string[] args)
        {
            var dt = new DateTimeOffset(2017, 2, 12, 7, 45, 55, TimeSpan.FromHours(2));
            IDateTimeOffsetAdjustment adjustment = new CompositeDateTimeOffsetAdjustment(
                new NextMonthAdjustment(),
                new BusinessHoursAdjustment(),
                new DutchBankDayAdjustment(),
                new UtcAdjustment());

            var adjusted = adjustment.Adjust(dt);

            Console.WriteLine(adjusted.ToString("o"));

            Console.ReadKey();
        }
    }
}
