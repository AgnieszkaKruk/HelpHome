using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CleaningDto
    {

        [Required]
        public int SurfaceToClean { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int PriceOffer { get; set; }
        // public Regularity Regularity { get; set; }
        // public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        // public List<Rooms> Rooms = new List<Rooms>();
    }
}
