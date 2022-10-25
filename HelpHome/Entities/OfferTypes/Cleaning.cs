using System.Text;

namespace HelpHome.Entities.OfferTypes
{
    public class Cleaning : Offer
    {
        public int SurfaceToClean { get; set; }
        public List<Room> rooms = new List<Room>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           foreach (var room in rooms)
            {
                sb.Append(room.ToString());
                sb.Append(", ");
            }
           
                
               
             return base.ToString() + $" Powierzchnia do sprzątania to ok {SurfaceToClean}m kw, pomieszczenia do sprzątania to {sb}. Cena usługi: {this.PriceOffer}";
        }
    }
}
