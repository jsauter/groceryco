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

        [TestMethod]
        public void TestLoadANormalCatalog()
        {
            var fileReader = new Mock<IProductCatalogFileReader>();
            fileReader.Setup(x => x.GetTextReader()).Returns(GetValidTestData);
            var testRepository = new ProductCatalogRepository(fileReader.Object);

            var catalog = testRepository.GetProductCatalog().ToList();

            Assert.IsTrue(catalog.Count() ==  2);

        }

        private TextReader GetValidTestData()
        {
            var fileString = @"Name,Price" + Environment.NewLine + "Apple,1.00" + Environment.NewLine + "Banana,0.75";
            return new StringReader(fileString);
        }
    }
}
