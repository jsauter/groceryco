namespace GroceryCo.Repositories
{
    public class BasketFileReader : FileReaderBase
    {
        public BasketFileReader(string fileName)
        {
            FileName = fileName;
        }
    }
}