using Domain.Entities;
using Domain.Entities.OfferentPreferences;
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
        
        

        //public ContactBy contact { get; set; }
        //public int Area { get; set; }
        public virtual List<Seeker> BlockedSeekers { get; set; } = new List<Seeker>();
        public List<CleaningPreference> CleaningPreferences { get; set; } = new List<CleaningPreference>();
        public List<CarpetWashingPreference> CarpetWashingPreferences { get; set; } = new List<CarpetWashingPreference>();
        public List<WindowsCleaningPreference> WindowsCleaningPreferences { get; set; } = new List<WindowsCleaningPreference>();
    }
}
