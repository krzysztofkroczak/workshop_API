using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
{
    public class BasketContentsPriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(Basket basket)
        {
            var sum = 0m;
            foreach (var p in basket)
                sum = sum + p.Price;
            return sum;
        }
    }
}
