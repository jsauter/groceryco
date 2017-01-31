using System;
using System.IO;

namespace GroceryCo.Tests
{
    public class BasketTestData
    {
        public TextReader GetValidTestData()
        {
            var fileString = @"Name" + Environment.NewLine + "Apple" + Environment.NewLine + "Banana" + Environment.NewLine + "Apple";
            return new StringReader(fileString);
        }
    }
}