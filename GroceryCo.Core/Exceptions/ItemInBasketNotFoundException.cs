using System;

namespace GroceryCo.Core.Exceptions
{
    public class ItemInBasketNotFoundException : Exception
    {
        public ItemInBasketNotFoundException(string message) : base(message)
        {
        }
        
    }
}