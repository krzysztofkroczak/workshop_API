using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
{
    public class CompositePriceCalculator : IPriceCalculator
    {
        public CompositePriceCalculator(params IPriceCalculator[] calculators)
        {
        }

        public decimal CalculatePrice(Basket basket)
        {
            throw new NotImplementedException();
        }
    }
}
