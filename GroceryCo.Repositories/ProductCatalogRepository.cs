using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using CsvHelper;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class ProductCatalogRepository : IProductCatalogRepository
    {
        private IProductCatalogFileReader _reader;

        public ProductCatalogRepository(IProductCatalogFileReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<ProductCatalogItem> GetProductCatalog()
        {
            var csv = new CsvReader(_reader.GetTextReader());

            var records = csv.GetRecords<ProductCatalogItem>();

            return records;
        }
    }
}