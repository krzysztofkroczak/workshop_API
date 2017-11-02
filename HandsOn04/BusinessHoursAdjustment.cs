using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn04
{
    public class BusinessHoursAdjustment : IDateTimeOffsetAdjustment
    {
        private readonly static TimeSpan startOfBussiness =
            TimeSpan.FromHours(9);
        private readonly static TimeSpan endOfBusiness =
            TimeSpan.FromHours(17);

        public DateTimeOffset Adjust(DateTimeOffset value)
        {
            // Warning: May not handle DST changes appropriately!
            // It's only example code...
            if (value.TimeOfDay < startOfBussiness)
                return value - value.TimeOfDay + startOfBussiness;
            if (endOfBusiness < value.TimeOfDay)
                return (value - value.TimeOfDay + startOfBussiness).AddDays(1);
            return value;
        }
    }
}
