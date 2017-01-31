using System.Collections.Generic;
using CsvHelper;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private IBasketFileReader _reader;

        public BasketRepository(IBasketFileReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<BasketItem> GetBasketItems()
        {
            var csv = new CsvReader(_reader.GetTextReader());

            var records = csv.GetRecords<BasketItem>();

            return records;
        }
    }
}