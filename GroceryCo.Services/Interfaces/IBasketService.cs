using System.Collections.Generic;
using GroceryCo.Core.Models;

namespace GroceryCo.Services.Interfaces
{
    public interface IBasketService
    {
        IEnumerable<BasketItem> GetBasketItems();
    }
}