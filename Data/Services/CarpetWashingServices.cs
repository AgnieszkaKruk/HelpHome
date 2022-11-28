using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;
using HelpHomeApi;
using HelpHomeApi.Exeptions;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILog _logger;
        public CarpetWashingServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;

        }


        public CarpetWashingDto GetById(int seekerId, int offerId)
        {
            _logger.Info($"CarpetWashing offer with id: {offerId} GET action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                 throw new NotFoundExeption("Seeker is not found");
            }
            var offer = _context.CarpetWashingOffers.Include(x => x.Address).FirstOrDefault(x => x.SeekerId == seekerId && x.Id == offerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                throw new NotFoundExeption("Offer is not found");
            }

            var offerDto = _mapper.Map<CarpetWashingDto>(offer);
            return offerDto;
        }

        public List<CarpetWashingDto> GetAll(int seekerId)
        {
            _logger.Info($"All CarpetWashing offers from Seeker with id: {seekerId} GET All action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                throw new NotFoundExeption("Seeker is not found");
            }

            var allOffers = _context.CarpetWashingOffers.Include(x => x.Address).Where(x => x.SeekerId == seekerId);

            var allOffersDto = _mapper.Map<List<CarpetWashingDto>>(allOffers);
            return allOffersDto;
        }

        public int CreateOffer(CreateCarpetWashingDto dto, int seekerId)
        {
            _logger.Info($"New CarpetWashing offer from Seeker with id: {seekerId} was created");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                throw new NotFoundExeption("Seeker is not found");
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

