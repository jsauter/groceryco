using System.Collections.Generic;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;
using GroceryCo.Services.Interfaces;

namespace GroceryCo.Services
{
    public class BasketService : IBasketService
    {
        private IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public IEnumerable<BasketItem> GetBasketItems()
        {
            return _basketRepository.GetItems();
        }
    }
}