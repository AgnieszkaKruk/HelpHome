using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CarpetWashingServices : ICarpetWashingServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        public CarpetWashingServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;

        }


        public CarpetWashingDto GetById(int seekerId, int offerId)
        {
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFpundExeption
            }
            var offer = _context.CarpetWashingOffers.FirstOrDefault(u => u.Id == offerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                return null; ///throw new NotFoundExeption
            }

            var offerDto = _mapper.Map<CarpetWashingDto>(offer);
            return offerDto;
        }

        public List<CarpetWashingDto> GetAll(int seekerId)
        {
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                return null; ///throw new NotFoundExeption
            }

            var allOffers = seeker.CarpetWaschingOffers;

            var allOffersDto = _mapper.Map<List<CarpetWashingDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateCarpetWashingDto dto, int seekerId)
        {

            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                return 0; ///throw new NotFpundExeption
            }
            var offer = _mapper.Map<CarpetWashing>(dto);
            offer.SeekerId = seekerId;
            _context.CarpetWashingOffers.Add(offer);
            seeker.CarpetWaschingOffers.Add(offer);
            _context.SaveChanges();
            return offer.Id;
        }
    }
}

