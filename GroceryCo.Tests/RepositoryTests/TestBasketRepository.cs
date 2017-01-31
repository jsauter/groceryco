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

        [TestMethod]
        public void TestLoadANormalBasket()
        {
            var fileReader = new Mock<IBasketFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(GetValidTestData);
            var testRepository = new BasketRepository(fileReader.Object);

            var catalog = testRepository.GetBasketItems().ToList();

            Assert.IsTrue(catalog.Count() ==  3);

        }

        private TextReader GetValidTestData()
        {
            var fileString = @"Name" + Environment.NewLine + "Apple" + Environment.NewLine + "Banana" + Environment.NewLine + "Apple";
            return new StringReader(fileString);
        }
    }
}
