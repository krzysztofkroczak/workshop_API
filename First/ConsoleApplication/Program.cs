using First;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var writer = new CompositeTextWriter(new ConsoleTextWriter(),
                new FileTextWriter(@"./Messages.txt"));
            
            writer.WriteLines("Foo");
            writer.WriteLines("Bar");
            writer.WriteLines("Baz");
            writer.Clear();
            writer.WriteLines("Ploeh");
            writer.WriteLines("Fnahh");
        }
    }
}