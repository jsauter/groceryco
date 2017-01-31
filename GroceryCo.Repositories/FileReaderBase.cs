using System.IO;

namespace GroceryCo.Repositories
{
    public class FileReaderBase
    {
        public string FileName { get; set; }

        public TextReader GetTextReader()
        {
            return File.OpenText(FileName);
        }
    }
}