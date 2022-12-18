using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CarpetWashingDto
    {
        public string Name = "Pranie dywanów";
        [Required]
        public int CarpetCount { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
        public virtual Address Address { get; set; }
    }
}
