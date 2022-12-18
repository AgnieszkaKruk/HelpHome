using Domain.Entities.Utils;
using HelpHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OfferentPreferences
{
    public class CleaningPreference
    {
        public int Id { get; set; }
        public string Name = "Sprzątanie";
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
       
        public int PriceOffer { get; set; }
        
        public Offerent Offerent { get; set; }
        public int OfferentId { get; set; }
        public Location  Location { get; set; }
        public int LocationId { get; set; }

    }
}
