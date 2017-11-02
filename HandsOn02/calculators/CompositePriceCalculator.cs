using System.Linq;

namespace Ploeh.Workshop.DPtoCT.HandsOn02.calculators
{
    public class CompositePriceCalculator : IPriceCalculator
    {
        private readonly IPriceCalculator[] _calculators;

        public CompositePriceCalculator(params IPriceCalculator[] calculators)
        {
            _calculators = calculators;
        }

        public decimal CalculatePrice(Basket basket)
        {
            return _calculators.Select(c=>c.CalculatePrice(basket)).Sum();
        }
    }
}
