using Domain.Entities;
using Domain.Entities.Utils;
using System.Text;

namespace HelpHome.Entities.OfferTypes
{
    public class Cleaning 
    {
        public int Id { get; set; }
        public string Name = "Sprzątanie";
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int SurfaceToClean { get; set; }
        public List<Rooms> Rooms = new List<Rooms>();
        public int PriceOffer { get; set; }
        public Seeker Seeker { get; set; }
        public int SeekerId { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var room in Rooms)
            {
                sb.Append(room.ToString());
                sb.Append(", ");
            }
            return $"Usługa: {Name}. Regularność: {Regularity}. Powierzchnia do sprzątania: {SurfaceToClean}m kw. Dodatkowe usługi: {additionalServices}. Cena usługi: {this.PriceOffer}";
        }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }



    }
}
