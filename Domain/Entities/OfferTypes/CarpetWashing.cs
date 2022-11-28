using Domain.Entities;
using Domain.Entities.Utils;

namespace HelpHome.Entities.OfferTypes
{
    public class CarpetWashing 
    {
        public int Id { get; set; }
        public string Name = "Pranie dywanów";
        public int CarpetCount { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int PriceOffer { get; set; }
        public Seeker Seeker { get; set; }
        public int SeekerId { get; set; }
        public override string ToString()
        {
            return $"Usługa: {Name}. Regularność: {Regularity}.Ilość dywanów do prania: {CarpetCount}. Dodatkowe usługi: {additionalServices}. Cena usługi: {this.PriceOffer}";
        }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }




    }

}
