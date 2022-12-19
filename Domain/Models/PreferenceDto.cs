using Domain.Entities;
using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PreferenceDto
    {
        public string Name { get; set; }
        public int PriceOffer { get; set; }
        public Location Location { get; set; }
        public Regularity Regularity { get; set; }
    }
}
