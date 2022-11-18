using HelpHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address
    {
        public int Id { get; set; } 
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public Offerent Offerent { get; set; }
        public int OfferentId { get; set; }
       

    
    

    }
}
