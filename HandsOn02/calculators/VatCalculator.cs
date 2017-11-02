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
            var vat = 0m;
            foreach (var p in basket)
            {
                // Not VAT on newspapers, in order to subsidise a free press.
                if (p.Name != "Newspaper")
                    vat = vat + p.Price * this.vatRate;
            }
            return vat;
        }
    }
}
