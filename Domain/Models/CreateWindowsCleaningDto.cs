using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateWindowsCleaningDto
    { 
        [Required]
        public int WindowsCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int SeekerId { get; set; }
        public int PriceOffer { get; set; }
        //public List<WindowsType>? windowsType = new List<WindowsType>();
        // public Regularity Regularity { get; set; }
        //public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
    }
}
