using System;
using System.Linq;
using GroceryCo.Core.Exceptions;
using GroceryCo.Core.Models;
using GroceryCo.Services;
using GroceryCo.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GroceryCo.Tests.ServiceTests
{
    [TestClass]
    public class RegisterServiceTests
    {
        [TestMethod]
        public void ScanItemRegisterTest()
        {
            var priceServiceMock = new Mock<IPriceService>();

            priceServiceMock.Setup(x => x.GetItemPrice(It.IsAny<string>()))
                .Returns(.50M);

            var basketItem = new BasketItem();
            basketItem.Name = "Apple";

            var registerService = new RegisterService(priceServiceMock.Object);

            registerService.Scan(basketItem);

            Assert.IsTrue(registerService.GetConsolidatedItems().Count() == 1);
        }

        [TestMethod]
        public void TotalCalculationIsCorrectTest()
        {
            var priceServiceMock = new Mock<IPriceService>();

            priceServiceMock.Setup(x => x.GetItemPrice(It.IsAny<string>()))
                .Returns(.50M);

            var basketItem = new BasketItem();
            basketItem.Name = "Apple";

            var registerService = new RegisterService(priceServiceMock.Object);

            registerService.Scan(basketItem);
            registerService.Scan(basketItem);
            registerService.Scan(basketItem);

            Assert.IsTrue(registerService.GetConsolidatedItems().Count() == 1);
            Assert.IsTrue(registerService.GetTotalPrice() == 1.50M);
        }

    }
}
