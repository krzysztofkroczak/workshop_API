using System;
using First;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new NonEmptyCollection<int>(42, new[] {1337, 123});
            Console.WriteLine("Items:");
            foreach (var i in result)
                Console.WriteLine("{0,9}", i);
            Console.WriteLine("Max: {0}", Accumulate(result));
            Console.ReadKey();
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
}