using Domain.Entities.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CreateOfferentDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        //public ContactBy contact { get; set; }
        //[Required]
        //public int Area { get; set; }
        // public List<Preference> preferences { get; set; } = new List<Preference>();

    }
}
