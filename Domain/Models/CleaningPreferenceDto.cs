using Domain.Entities.Utils;
using HelpHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CleaningPreferenceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Regularity Regularity { get; set; }
        public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int PriceOffer { get; set; }
        public string City { get; set; }
        public string District { get; set; }

    }
}
