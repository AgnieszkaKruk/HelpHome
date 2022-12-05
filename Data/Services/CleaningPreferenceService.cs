using AutoMapper;
using Domain.Models;
using Data.Exceptions;
using HelpHomeApi;
using System.Data.Entity;

namespace Data.Services
{
    public class CleaningPreferenceServices : ICleaningPreferencesServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public CleaningPreferenceServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public CleaningPreferenceDto GetById(int offerentId, int preferenceId)
        {
            _logger.Info($"Cleaning offer with id: {preferenceId} GET action invoked");
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == offerentId);
            if (offerent is null)
            {
                throw new NotFoundException("Seeker is not found");
            }
            var preference = _context.CleaningPreferences.FirstOrDefault(x => x.Id == offerentId);
            if (preference is null || preference.OfferentId != offerentId)
            {
                throw new NotFoundException("Offer is not found");
            }

            var preferenceDto = _mapper.Map<CleaningPreferenceDto>(preference);
            return preferenceDto;
        }

        public List<CleaningPreferenceDto> GetAll(int offerentId)
        {

            _logger.Info($"All CarpetWashing offers from Seeker with id: {offerentId} GET All action invoked");
            var offerent = _context.Seekers.Include(x => x.CleaningOffers).FirstOrDefault(u => u.Id == offerentId);
            if (offerent is null)
            {
                throw new NotFoundException("Seeker is not found");
            }

            var allPreferences = offerent.CleaningOffers;

            var allPreferencesDto = _mapper.Map<List<CleaningPreferenceDto>>(allPreferences);
            return allPreferencesDto;
        }

        



        //public int CreateOffer(CreateCleaningDto dto, int seekerId)
        //{
        //    _logger.Info($"New Cleaning offer from Seeker with id: {seekerId} was created");
        //    var seeker = _context.Seekers.FirstOrDefault(u => u.Id == seekerId);
        //    if (seeker is null)
        //    {

        //        throw new NotFoundExeption("Seeker is not found");
        //    }
        //    var offer = _mapper.Map<Cleaning>(dto);
        //    offer.SeekerId = seekerId;
        //    _context.CleaningOffers.Add(offer);
        //    seeker.CleaningOffers.Add(offer);
        //    _context.SaveChanges();
        //    return offer.Id;
        //}
    }
}

