using System;
using System.Collections.Generic;
using System.Linq;

namespace Ploeh.Workshop.DPtoCT.HandsOn03
{
    public class First<T>
    {
        private readonly T item;
        private readonly bool hasItem;

        public First()
        {
            hasItem = false;
        }

        public First(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.item = item;
            hasItem = true;
        }

        public First<T> FindFirst(First<T> other)
        {
            return this.hasItem 
                ? this 
                : other;
        }

        public override string ToString()
        {
            var itemString = hasItem ? item.ToString() : "";
            return $"First<{typeof(T).Name}>({itemString})";
        }
    }

    public static class First
    {
        public static First<T> Identity<T>()
        {
            return new First<T>();
        }

        public static First<T> Accumulate<T>(IReadOnlyList<First<T>> firsts)
        {
            var acc = Identity<T>();
            return firsts.Aggregate(acc, (current, first) => current.FindFirst(first));
        }
    }
}
