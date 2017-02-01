using System;
using System.IO;
using System.Linq;
using GroceryCo.Repositories;
using GroceryCo.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GroceryCo.Tests.RepositoryTests
{
    [TestClass]
    public class TestBasketRepository
    {
        private readonly BasketTestData _basketTestData = new BasketTestData();

        [TestMethod]
        public void TestLoadANormalBasket()
        {
            var fileReader = new Mock<IBasketFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(new BasketTestData().GetValidTestData);
            var testRepository = new BasketRepository(fileReader.Object);

            var catalog = testRepository.GetItems().ToList();

            Assert.IsTrue(catalog.Count() ==  3);

        }
    }
}
