using System;
using System.Collections.Generic;
using System.Linq;

namespace Ploeh.Workshop.DPtoCT.HandsOn03
{
    public class Last<T>
    {
        private readonly T item;
        private readonly bool hasItem;

        public Last()
        {
            hasItem = false;
        }

        public Last(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.item = item;
            hasItem = true;
        }

        public Last<T> FindLast(Last<T> other)
        {
            return other.hasItem 
                ? other 
                : this;
        }

        public override string ToString()
        {
            var itemString = hasItem ? item.ToString() : "";
            return $"Last<{typeof(T).Name}>({itemString})";
        }
    }

    public static class Last
    {
        public static Last<T> Identity<T>()
        {
            return new Last<T>();
        }

        public static Last<T> Accumulate<T>(IReadOnlyList<Last<T>> lasts)
        {
            var acc = Identity<T>();
            return lasts.Aggregate(acc, (current, last) => current.FindLast(last));
        }
    }
}
