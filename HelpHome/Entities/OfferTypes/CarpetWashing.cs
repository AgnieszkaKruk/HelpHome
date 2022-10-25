namespace HelpHome.Entities.OfferTypes
{
    public class CarpetWashing : Offer
    {
        public string Name = "Pranie dywanów";
        public int CarpetCount { get; set; }
        public override string ToString()
        {
             return base.ToString() + $" Ilość dywanów do prania: {CarpetCount}. Cena usługi: {this.PriceOffer}";
        }

    }

}
