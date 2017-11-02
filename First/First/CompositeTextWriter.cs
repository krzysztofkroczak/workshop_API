namespace First
{
    public class CompositeTextWriter : ITextWriter
    {
        private readonly ITextWriter[] _writers;

        public CompositeTextWriter(params ITextWriter[] writers)
        {
            _writers = writers;
        }
        public void Clear()
        {
            foreach (var writer in _writers)
            {
                writer.Clear();
            }
        }

        public void WriteLines(string text)
        {
            foreach (var writer in _writers)
            {
                writer.WriteLines(text);
            }
        }
    }
}