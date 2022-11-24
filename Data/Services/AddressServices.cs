using AutoMapper;
using Domain.Entities;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using Microsoft.AspNetCore.Mvc;
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


        public Address Createaddress(Address address, int offerId, int seekerId) // typ oferty przekazac jako parametr
        {
            var offer = _context.CleaningOffers.FirstOrDefault(u => u.Id == seekerId);
            
            if (offer is null)
            {
                return null; ///throw new NotFpundExeption
            }
            offer.Id = offerId;
            offer.Address = address;

            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;

        }

        public Address GetById(int offerId, string offertype)
        {
            Address address = null;
            if(offertype == "carpetwashingoffers")
            {
                address = _context.CarpetWashingOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }
            else if (offertype== "cleaningoffers")
            {
                address = _context.CleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }
            else if (offertype == "windowscleaningoffers")
            {
                address = _context.WindowsCleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.Id == offerId).Address;
            }
           
            if (address is null )
            {
                return null; ///throw new NotFoundExeption
            }
            return address;
        }



    }

        
}
