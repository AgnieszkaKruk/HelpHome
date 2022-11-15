using Domain.Entities.Utils;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OfferentDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public ContactBy contact { get; set; }

        public List<Preference> preferences { get; set; } = new List<Preference>();

    }
}
