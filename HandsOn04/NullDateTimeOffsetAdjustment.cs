using System;

namespace Ploeh.Workshop.DPtoCT.HandsOn04
{
    public class NullDateTimeOffsetAdjustment : IDateTimeOffsetAdjustment
    {
        public DateTimeOffset Adjust(DateTimeOffset value)
        {
            return value;
        }
    }
}