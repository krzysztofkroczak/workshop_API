using System;

namespace First
{
    public class ConsoleTextWriter : ITextWriter
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void WriteLines(string text)
        {
            Console.WriteLine(text);
        }
    }
}