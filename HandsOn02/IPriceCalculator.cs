using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ploeh.Workshop.DPtoCT.HandsOn02
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(Basket basket);
    }
}
