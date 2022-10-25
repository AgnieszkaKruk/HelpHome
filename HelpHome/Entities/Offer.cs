using HelpHome.Entities.OfferTypes;
using System.ComponentModel.DataAnnotations;

namespace HelpHome.Entities
{
    public abstract class Offer
    {
       
        public Guid Id { get; set; }
        public string Name  { get; set;}
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int PriceOffer { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public override string ToString()
        {
            return $"Offer: {Name} with Regularity: {Regularity}. Additional services: {additionalServices}";
        }

    }
}
