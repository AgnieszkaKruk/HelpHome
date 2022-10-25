using System.Text;

namespace HelpHome.Entities.OfferTypes
{
    public class WindowsCleaning : Offer
    {
        public int WindowsCount { get; set; }
        public List<WindowsType>? windowsType = new List<WindowsType>();
        public override string ToString()
            
        {
            StringBuilder sb= new StringBuilder();
            foreach(WindowsType type in windowsType)
            {
                sb.Append(type.ToString());
                sb.Append(", ");
            }
            return base.ToString() + $" Ilość okien do umycia: {WindowsCount}. Rodzaje okien: {sb}. Cena usługi: {this.PriceOffer}";
        }
    }

}
