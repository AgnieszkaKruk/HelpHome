using Domain.Entities;
using Domain.Entities.Utils;
using HelpHome.Entities.OfferTypes;

namespace HelpHome.Entities
{
    public class Seeker 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
  

        public List<Offerent> favouriteOfferents = new List<Offerent>();
        public List<Cleaning> CleaningOffers = new List<Cleaning>();
        public List<CarpetWashing> CarpetWaschingOffers = new List<CarpetWashing>();
        public List<WindowsCleaning> WindowsCleaningOffers = new List<WindowsCleaning>();

    }
}
