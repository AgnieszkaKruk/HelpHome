using AutoMapper;
using Data;
using Domain.Models;
using HelpHome.Entities.OfferTypes;
using HelpHomeApi;
using Microsoft.EntityFrameworkCore;
using Data.Exceptions;

namespace Domain.Services
{
    public class WindowsCleaningServices : IWindowsCleaningServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public WindowsCleaningServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public WindowsCleaningDto GetById(int seekerId, int offerId)
        {
            _logger.Info($"WindowsCleaning offer with id: {offerId} GET action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                throw new NotFoundException("Seeker is not found");
            }
            var offer = _context.WindowsCleaningOffers.Include(x => x.Address).FirstOrDefault(x => x.SeekerId == seekerId && x.Id == offerId);
            if (offer is null )
            {
                throw new NotFoundException("Offer is not found");
            }

            var offerDto = _mapper.Map<WindowsCleaningDto>(offer);
            return offerDto;
        }

        public List<WindowsCleaningDto> GetAll(int seekerId)
        {
            _logger.Info($"All CWindowsCleaning offers from Seeker with id: {seekerId} GET All action invoked");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {
                throw new NotFoundException("Seeker is not found");
            }

            var allOffers = _context.WindowsCleaningOffers.Include(s => s.Address).Where(u => u.SeekerId == seekerId).ToList();

            var allOffersDto = _mapper.Map<List<WindowsCleaningDto>>(allOffers);
            return allOffersDto;
        }




        public int CreateOffer(CreateWindowsCleaningDto dto, int seekerId)
        {
            _logger.Info($"New WindowsCleaning offer from Seeker with id: {seekerId} was created");
            var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
            if (seeker is null)
            {

                throw new NotFoundException("Seeker is not found");
            }
            var offer = _mapper.Map<WindowsCleaning>(dto);
            offer.SeekerId = seekerId;
            _context.WindowsCleaningOffers.Add(offer);
            seeker.WindowsCleaningOffers.Add(offer);
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

