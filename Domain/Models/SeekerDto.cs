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
    public class SeekerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ContactBy contact { get; set; }


        public List<Cleaning> CleaningOffers { get; set; } = new List<Cleaning>();
        public List<CarpetWashing> CarpetWashingOffers { get; set; } = new List<CarpetWashing>();
        public List<WindowsCleaning> WindowsCleaningOffers { get; set; } = new List<WindowsCleaning>();

    }
}
