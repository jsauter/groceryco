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

        public SelfCheckout(IPriceService priceService, IBasketService basketService)
        {
            _priceService = priceService;
            _basketService = basketService;
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

                    basketItem.IsCheckedOut = true;
                }
                catch (ItemInBasketNotFoundException)
                {
                    basketItem.IsCheckedOut = false;
                    Console.WriteLine($"Item {basketItem.Name} not in system, please see customer service rep.");
                }

            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Printing Receipt...");

            Console.WriteLine("Reciept for purchase at GroceryCo");
            Console.WriteLine();
            Console.WriteLine();

            var checkedOutItems = listOfBasketItems.Where(x => x.IsCheckedOut)
                .GroupBy(n => n.Name, (key, element) => new { Key = key, Count = element.Distinct().Count() });              

            foreach (var item in checkedOutItems)
            {
                Console.WriteLine($"{item.Key} x {item.Count} ${_priceService.GetItemPrice(item.Key) * item.Count}");    
            }

            var total = listOfBasketItems.Where(x => x.IsCheckedOut).Sum(x => _priceService.GetItemPrice(x.Name));


            Console.WriteLine();
            Console.WriteLine($"Total: ${total}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Thank you please come again!");
            Console.ReadLine();
        }
    }
}