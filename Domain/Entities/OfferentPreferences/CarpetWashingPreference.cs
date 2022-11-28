using Domain.Entities.Utils;
using HelpHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OfferentPreferences
{
    public class CarpetWashingPreference
    {
        public int Id { get; set; }
        public string Name = "Pranie dywanów";
        public CarpetSize CarpetSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int PriceOffer { get; set; }
        public Offerent Offerent { get; set; }
        public int OfferentId { get; set; }
       
        
    }
}
