using System.Collections.Generic;
using GroceryCo.Core.Models;

namespace GroceryCo.Services.Interfaces
{
    public interface IRegisterService
    {
        void Scan(BasketItem item);
        IEnumerable<KeyValuePair<string,decimal>> GetConsolidatedItems();
        decimal GetTotalPrice();
    }
}