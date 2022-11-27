using Domain.Entities.Utils;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RegisterOfferentDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; } = 1;

       



    }
}
