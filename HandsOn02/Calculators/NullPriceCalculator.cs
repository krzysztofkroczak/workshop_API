namespace Ploeh.Workshop.DPtoCT.HandsOn02.calculators
{
    public class NullPriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(Basket basket)
        {
            return 0;
        }
    }
}