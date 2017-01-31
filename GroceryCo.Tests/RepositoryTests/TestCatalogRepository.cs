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
    public class TestCatalogRepository
    {
        private readonly CatalogTestData _catalogTestData = new CatalogTestData();

        [TestMethod]
        public void TestLoadANormalCatalog()
        {
            var fileReader = new Mock<IProductCatalogFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(_catalogTestData.GetValidTestData());
            var testRepository = new ProductCatalogRepository(fileReader.Object);

            var catalog = testRepository.GetProductCatalog().ToList();

            Assert.IsTrue(catalog.Count() ==  2);

        }
    }
}
