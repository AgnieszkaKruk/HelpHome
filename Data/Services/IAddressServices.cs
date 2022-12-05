using Domain.Entities;
using Domain.Models;
using HelpHome.Entities;

namespace Data.Services
{
    public interface IAddressServices
    {
       
      
        public Address GetById(int offerId, string offertype);
    }
}
