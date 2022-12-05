using Domain.Entities;
using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateCarpetWashingDto
    {
        [Required] //dodac zakres wartości
        public int CarpetCount { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        //public Regularity Regularity { get; set; }
       // public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public int PriceOffer { get; set; }
       
        public int SeekerId { get; set; }
        public Address Address { get; set; }
    }
}
