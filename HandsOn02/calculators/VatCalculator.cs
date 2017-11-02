using System.Linq;

namespace Ploeh.Workshop.DPtoCT.HandsOn02.calculators
{
    public class VatCalculator : IPriceCalculator
    {
        private readonly decimal vatRate;

        public VatCalculator(decimal vatRate)
        {
            this.vatRate = vatRate;
        }

        public decimal CalculatePrice(Basket basket)
        {
            // Not VAT on newspapers, in order to subsidise a free press.
            return basket.Where(p => p.Name != "Newspaper")
                .Sum(p => p.Price * vatRate);
        }
    }
}
