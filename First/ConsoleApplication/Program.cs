using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using First;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //expected output:
            // Items:
            //42
            //1337
            //123
            //Max: 1337
            var result = new NonEmptyCollection<int>(42, new[] {1337, 123});
            Console.WriteLine("Items:");
            foreach (var i in result)
                Console.WriteLine("{0,9}", i);
            Console.WriteLine("Max: {0}", Accumulate(result));
            Console.ReadKey();
        }

        private static int Accumulate(NonEmptyCollection<int> result)
        {
            return result.Aggregate(Math.Max);
        }

        private static void First()
        {
            var writer = new CompositeTextWriter(new ConsoleTextWriter(),
                new FileTextWriter(@"./Messages.txt"), new NullTextWriter());

            writer.WriteLines("Foo");
            writer.WriteLines("Bar");
            writer.WriteLines("Baz");
            writer.Clear();
            writer.WriteLines("Ploeh");
            writer.WriteLines("Fnahh");

            Console.ReadKey();
        }
    }

    internal class NonEmptyCollection<T> : IEnumerable<T>
    {
        private readonly IList<T> col;

        public NonEmptyCollection(T i, T[] ints)
        {
            col = ints.ToList();
            col.Insert(0, i);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return col.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}