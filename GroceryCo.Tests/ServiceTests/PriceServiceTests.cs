using System;
using GroceryCo.Core.Exceptions;
using GroceryCo.Core.Models;
using GroceryCo.Repositories;
using GroceryCo.Repositories.Interfaces;
using GroceryCo.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GroceryCo.Tests.ServiceTests
{
    [TestClass]
    public class PriceServiceTests
    {
        private readonly CatalogTestData _catalogTestData = new CatalogTestData();

        [TestMethod]
        public void GetItemPrice()
        {
            var fileReader = new Mock<IProductCatalogFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(_catalogTestData.GetValidTestData());

            var testRepository = new ProductCatalogRepository(fileReader.Object);

            var priceService = new PriceService(testRepository);

            var saleItem = new BasketItem()
            {
                Name = "Apple"
            };

            var normalItem = new BasketItem()
            {
                Name = "Banana"
            };

            var saleItemResult = priceService.GetItemPrice(saleItem);
            var normalItemResult = priceService.GetItemPrice(normalItem);

            Assert.IsTrue(saleItemResult == 0.50M);
            Assert.IsTrue(normalItemResult == 0.75M);
        }

        [TestMethod]
        [ExpectedException(typeof(ItemInBasketNotFoundException))]
        public void IfItemNotFoundExceptionThrown()
        {
            var fileReader = new Mock<IProductCatalogFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(_catalogTestData.GetValidTestData());

            var testRepository = new ProductCatalogRepository(fileReader.Object);

            var priceService = new PriceService(testRepository);

            var notFoundItem = new BasketItem()
            {
                Name = "Cheese"
            };

            priceService.GetItemPrice(notFoundItem);            
        }
    }
}
