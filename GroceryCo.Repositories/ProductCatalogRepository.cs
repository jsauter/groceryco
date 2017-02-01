using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using CsvHelper;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class ProductCatalogRepository : RepositoryBase<ProductCatalogItem>, IProductCatalogRepository
    {
        public ProductCatalogRepository(IProductCatalogFileReader reader) : base(reader)
        {
        }        
    }
}