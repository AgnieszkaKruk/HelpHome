using Domain.Entities;
using Domain.Entities.Utils;
using HelpHome.Entities.OfferTypes;

namespace HelpHome.Entities
{
    public class Offerent

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //public virtual List<Address> Addresses { get; set; } = new List<Address>();
        

        //public ContactBy contact { get; set; }
        //public int Area { get; set; }
        public virtual List<Seeker> BlockedSeekers { get; set; } = new List<Seeker>();
       // public List<Preference> preferences { get; set; } = new List<Preference>();
    }
}
