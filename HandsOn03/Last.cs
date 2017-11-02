using System;
using System.Collections.Generic;

namespace Ploeh.Workshop.DPtoCT.HandsOn03
{
    public class Last<T>
    {
        private readonly T item;
        private readonly bool hasItem;

        public Last()
        {
            this.hasItem = false;
        }

        public Last(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.item = item;
            this.hasItem = true;
        }

        public Last<T> FindLast(Last<T> other)
        {
            if (other.hasItem)
                return other;
            else
                return this;
        }

        public override string ToString()
        {
            var itemString = this.hasItem ? this.item.ToString() : "";
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
            foreach (var last in lasts)
                acc = acc.FindLast(last);
            return acc;
        }
    }
}
