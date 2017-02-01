using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class ProductCatalogFileReader : FileReaderBase, IProductCatalogFileReader
    {
        public ProductCatalogFileReader(string fileName)
        {
            FileName = fileName;
        }
    }
}