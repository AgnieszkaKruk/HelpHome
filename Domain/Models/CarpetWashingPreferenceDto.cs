using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CarpetWashingPreferenceDto
    {
        public CarpetSize CarpetSize { get; set; }
        public int PriceOffer { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
