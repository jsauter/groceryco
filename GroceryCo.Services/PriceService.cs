using System.Linq;
using GroceryCo.Core.Exceptions;
using GroceryCo.Core.Models;
using GroceryCo.Repositories.Interfaces;
using GroceryCo.Services.Interfaces;

namespace GroceryCo.Services
{
    public class PriceService : IPriceService
    {
        private IProductCatalogRepository _productCatalogRepository;

        public PriceService(IProductCatalogRepository productCatalogRepository)
        {
            _productCatalogRepository = productCatalogRepository;
        }

        public decimal GetItemPrice(BasketItem item)
        {
            var catalogItem = GetProductCatalogItem(item);

            return catalogItem.SalePrice == 0 ? catalogItem.Price : catalogItem.SalePrice;
        }

        public decimal GetItemPrice(string itemName)
        {
            return GetItemPrice(new BasketItem()
            {
                Name = itemName
            });
        }

        public bool IsItemOnSale(BasketItem item)
        {
            var catalogItem = GetProductCatalogItem(item);

            return catalogItem.SalePrice != 0;
        }

        private ProductCatalogItem GetProductCatalogItem(BasketItem item)
        {
            var catalogItem = _productCatalogRepository.GetItems().Where(x => x.Name == item.Name).FirstOrDefault();

            if (catalogItem == null)
            {
                throw new ItemInBasketNotFoundException(string.Format("No item found named {0} in product catalog.",
                    item.Name));
            }

            return catalogItem;
        }
    }
}