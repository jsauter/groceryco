using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class BasketFileReader : FileReaderBase, IBasketFileReader
    {
        public BasketFileReader(string fileName)
        {
            FileName = fileName;
        }
    }
}