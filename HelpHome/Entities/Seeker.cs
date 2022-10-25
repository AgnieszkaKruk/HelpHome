namespace HelpHome.Entities
{
    public class Seeker : User
    {
        public List<User> favouriteUsers = new List<User>();
        public List<Offer> needsHelpOffers = new List<Offer>();

    }
}
