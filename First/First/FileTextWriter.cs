using System.IO;

namespace First
{
    public class FileTextWriter : ITextWriter
    {
        private readonly string _fileName;

        public FileTextWriter(string fileName)
        {
            _fileName = fileName;
        }
        
        public void Clear()
        {
            File.WriteAllText(_fileName, "");
        }

        public void WriteLines(string text)
        {
            File.AppendAllLines(_fileName, new[]{text});
        }
    }
}