using System.Collections.Generic;
using CsvHelper;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;

namespace GroceryCo.Repositories
{
    public class BasketRepository : RepositoryBase<BasketItem>, IBasketRepository
    {
        public BasketRepository(IBasketFileReader reader) : base(reader) 
        {            
        }
        
    }
}