using System;
using Ploeh.Workshop.DPtoCT.HandsOn02.calculators;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket
            {
                new Product {Name = "Chocolate", Price = 40m},
                new Product {Name = "Water", Price = 2.4m},
                new Product {Name = "Newspaper", Price = 10m},
                new Product {Name = "Water", Price = 2.4m}
            };

            IPriceCalculator calculator =
                new CompositePriceCalculator(
                    new BasketContentsPriceCalculator(),
                    new VatCalculator(.25m),
                    new NullPriceCalculator()); // Whopping Danish VAT!!

            var price = calculator.CalculatePrice(basket);

            Console.WriteLine($"Price: {price}");

            Console.ReadKey();
        }
    }
}
