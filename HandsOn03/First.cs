using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn03
{
    public class First<T>
    {
        private readonly T item;
        private readonly bool hasItem;

        public First()
        {
            this.hasItem = false;
        }

        public First(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.item = item;
            this.hasItem = true;
        }

        public First<T> FindFirst(First<T> other)
        {
            if (this.hasItem)
                return this;
            else
                return other;
        }

        public override string ToString()
        {
            var itemString = this.hasItem ? this.item.ToString() : "";
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
            foreach (var first in firsts)
                acc = acc.FindFirst(first);
            return acc;
        }
    }
}
