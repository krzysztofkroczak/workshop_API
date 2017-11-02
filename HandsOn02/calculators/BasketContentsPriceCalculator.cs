using System.Linq;

namespace Ploeh.Workshop.DPtoCT.HandsOn02.calculators
{
    public class BasketContentsPriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(Basket basket)
        {
            return basket.Sum(p => p.Price);
        }
    }
}
