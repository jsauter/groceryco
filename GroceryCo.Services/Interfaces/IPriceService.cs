using GroceryCo.Core.Models;

namespace GroceryCo.Services.Interfaces
{
    public interface IPriceService
    {
        decimal GetItemPrice(BasketItem item);
        decimal GetItemPrice(string itemName);
        bool IsItemOnSale(BasketItem item);        
    }
}