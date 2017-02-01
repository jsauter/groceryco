using System;
using System.Linq;
using GroceryCo.Core.Exceptions;
using GroceryCo.Core.Models;
using GroceryCo.Interfaces;
using GroceryCo.Services.Interfaces;

namespace GroceryCo
{
    public class SelfCheckout : ISelfCheckout
    {
        private IPriceService _priceService;
        private IBasketService _basketService;
        private IRegisterService _registerService;

        public SelfCheckout(IPriceService priceService, IBasketService basketService, IRegisterService registerService)
        {
            _priceService = priceService;
            _basketService = basketService;
            _registerService = registerService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to GroceryCo Self Checkout - Where you do all the work and we don't pay you a dime.");

            Console.WriteLine();
            Console.WriteLine();

            var listOfBasketItems = _basketService.GetBasketItems();

            foreach (var basketItem in listOfBasketItems)
            {
                try
                {
                    if (_priceService.IsItemOnSale(basketItem))
                    {
                        Console.WriteLine($"BEEP - {basketItem.Name} scanned. ${_priceService.GetItemPrice(basketItem)} SALE ITEM! ");
                    }
                    else
                    {
                        Console.WriteLine($"BEEP - {basketItem.Name} scanned. ${_priceService.GetItemPrice(basketItem)}");                        
                    }

                    _registerService.Scan(basketItem);   
                }
                catch (ItemInBasketNotFoundException)
                {                    
                    Console.WriteLine($"Item {basketItem.Name} not in system, please see customer service rep.");
                }

            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Printing Receipt...");

            Console.WriteLine("Reciept for purchase at GroceryCo");
            Console.WriteLine();
            Console.WriteLine();
            
            foreach (var item in _registerService.GetCombinedPrices())
            {
                Console.WriteLine($"{item.Key} x {item.Value} ${_priceService.GetItemPrice(item.Key) * item.Value}");    
            }

            Console.WriteLine();
            Console.WriteLine($"Total: ${_registerService.GetTotalPrice()}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Thank you please come again!");
            Console.ReadLine();
        }
    }
}