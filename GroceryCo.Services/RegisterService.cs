using System.Collections.Generic;
using System.Linq;
using GroceryCo.Core.Models;
using GroceryCo.Services.Interfaces;

namespace GroceryCo.Services
{
    public class RegisterService : IRegisterService
    {
        private List<BasketItem> _scannedBasketItems;
        private IPriceService _priceService;
        
        public RegisterService(IPriceService priceService)
        {
            _priceService = priceService;
            _scannedBasketItems = new List<BasketItem>();
        }

        public void Scan(BasketItem item)
        {
            _scannedBasketItems.Add(item);
        }

        public IEnumerable<KeyValuePair<string,decimal>> GetCombinedPrices()
        {
           return _scannedBasketItems.GroupBy(n => n.Name, (key, element) => new KeyValuePair<string, decimal>(key, element.Distinct().Count()));
        }

        public decimal GetTotalPrice()
        {
            return _scannedBasketItems.Sum(x => _priceService.GetItemPrice(x.Name));
        }
    }
}