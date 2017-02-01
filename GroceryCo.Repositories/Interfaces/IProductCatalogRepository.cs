using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GroceryCo.Core.Models;

namespace GroceryCo.Repositories.Interfaces
{
    public interface IProductCatalogRepository : IRepository<ProductCatalogItem>
    {
    }
}