using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
{
    class Program
    {
        static void Main(string[] args)
        {
            var basket = new Basket();
            basket.Add(new Product { Name = "Chocolate", Price = 40m });
            basket.Add(new Product { Name = "Water", Price = 2.4m });
            basket.Add(new Product { Name = "Newspaper", Price = 10m });
            basket.Add(new Product { Name = "Water", Price = 2.4m });

            IPriceCalculator calculator =
                new CompositePriceCalculator(
                    new BasketContentsPriceCalculator(),
                    new VatCalculator(.25m)); // Whopping Danish VAT!!

            var price = calculator.CalculatePrice(basket);

            Console.WriteLine($"Price: {price}");
        }
    }
}
