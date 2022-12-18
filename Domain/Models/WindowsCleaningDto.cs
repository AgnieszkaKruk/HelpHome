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
    public class WindowsCleaningDto
    {
        public string Name = "Mycie okien";
        [Required]
        public int WindowsCount { get; set; }
        
        //public List<WindowsType>? windowsType = new List<WindowsType>();
        // public Regularity Regularity { get; set; }
        //public List<AdditionalServices>? additionalServices = new List<AdditionalServices>();
        public virtual Address Address { get; set; }
    }
}
