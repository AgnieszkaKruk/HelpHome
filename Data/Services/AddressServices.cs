using Data.Exceptions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly HelpHomeDbContext _context;
        public AddressServices(HelpHomeDbContext helpHomeDbContext)
        {
            _context = helpHomeDbContext;
        }


       
          

        public Address GetById(int offerId, string offertype)
        {
            Address address = null;
            if (offertype == "carpetwashingoffers")
            {
                address = _context.CarpetWashingOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }
            else if (offertype == "cleaningoffers")
            {
                address = _context.CleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }
            else if (offertype == "windowscleaningoffers")
            {
                address = _context.WindowsCleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }

            if (address is null)
            {
                return null; ///throw new NotFoundExeption
            }
            return address;
        }





    }


}
