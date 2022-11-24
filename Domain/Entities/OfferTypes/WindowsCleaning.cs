using Domain.Entities;
using Domain.Entities.Utils;
using System.Text;

namespace HelpHome.Entities.OfferTypes
{
    public class WindowsCleaning 
    {
        public int Id { get; set; }
        public string Name = "Mycie okien";
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int WindowsCount { get; set; }
        public List<WindowsType>? windowsType = new List<WindowsType>();
        public int PriceOffer { get; set; }
        public Seeker Seeker { get; set; }
        public int SeekerId { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (WindowsType type in windowsType)
            {
                sb.Append(type.ToString());
                sb.Append(", ");
            }
            return $"Usługa: {Name}. Regularność: {Regularity}.Ilość okien do umycia: {WindowsCount}. Rodzaje okien: {sb}. Dodatkowe usługi: {additionalServices}. Cena usługi: {this.PriceOffer}";
        }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }


    }

}
