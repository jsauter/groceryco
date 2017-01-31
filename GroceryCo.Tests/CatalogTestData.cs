using System;
using System.IO;

namespace GroceryCo.Tests
{
    public class CatalogTestData
    {
        public TextReader GetValidTestData()
        {
            var fileString = @"Name,Price,SalePrice" + Environment.NewLine + "Apple,1.00,0.50" + Environment.NewLine + "Banana,0.75,0.00";
            return new StringReader(fileString);
        }
    }
}