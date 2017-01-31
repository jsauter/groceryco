using System.IO;

namespace GroceryCo.Repositories.Interfaces
{
    public interface IFileReaderBase
    {
        TextReader GetTextReader();
    }
}