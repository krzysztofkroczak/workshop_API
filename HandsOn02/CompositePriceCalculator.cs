using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
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
