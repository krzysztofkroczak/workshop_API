using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn04
{
    public class CompositeDateTimeOffsetAdjustment : IDateTimeOffsetAdjustment
    {
        private readonly IReadOnlyCollection<IDateTimeOffsetAdjustment> adjustments;

        public CompositeDateTimeOffsetAdjustment(
            params IDateTimeOffsetAdjustment[] adjustments)
        {
            this.adjustments = adjustments;
        }

        public DateTimeOffset Adjust(DateTimeOffset value)
        {
            return adjustments.Aggregate(value, (current, ad) => ad.Adjust(current));
        }
    }
}
