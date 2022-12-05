using AutoMapper;
using Data;
using Data.Exceptions;
using Domain.Models;
using HelpHome.Entities.OfferTypes;
using HelpHomeApi;
using Microsoft.EntityFrameworkCore;

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
                 throw new NotFoundException("Seeker is not found");
            }
            var offer = _context.CarpetWashingOffers.Include(x => x.Address).FirstOrDefault(x => x.SeekerId == seekerId && x.Id == offerId);
            if (offer is null || offer.SeekerId != seekerId)
            {
                throw new NotFoundException("Offer is not found");
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
                throw new NotFoundException("Seeker is not found");
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

                throw new NotFoundException("Seeker is not found");
            }
            var offer = _mapper.Map<CarpetWashing>(dto);
            offer.SeekerId = seekerId;
            _context.CarpetWashingOffers.Add(offer);
            seeker.CarpetWashingOffers.Add(offer);
            _context.SaveChanges();
            return offer.Id;
        }

        public void Delete(int id)
        {
            _logger.Warn($"Offer with id: {id} DELETE action invoked");
            var offer = _context.CarpetWashingOffers.FirstOrDefault(u => u.Id == id);
            if (offer is null)
            {
                throw new NotFoundException("Offer is not found");
            }
            else
            {
                _context.CarpetWashingOffers.Remove(offer);
                _context.SaveChanges();

            }
        }
    }
}

