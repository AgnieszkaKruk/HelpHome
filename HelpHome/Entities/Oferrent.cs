namespace HelpHome.Entities
{
    public class Oferrent: User

    {
        public List<User> blockedUsers = new List<User>();
        public List<Offer> myServicesOffers = new List<Offer>();
    }
}
