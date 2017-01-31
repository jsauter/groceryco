using GroceryCo.Core.Models;

namespace GroceryCo.Services.Interfaces
{
    public interface IPriceService
    {
        decimal GetItemPrice(BasketItem item);
        bool IsItemOnSale(BasketItem item);
    }
}