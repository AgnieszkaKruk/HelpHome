using AutoMapper;
using Domain.Models;
using HelpHomeApi.Exeptions;
using HelpHomeApi;
using System.Data.Entity;
using Domain.Entities.OfferentPreferences;
using HelpHome.Entities;

namespace Data.Services
{
    public class CarpetWashingPreferenceServices : ICarpetWashingPreferenceServices
    {
        private readonly HelpHomeDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILog _logger;
        public CarpetWashingPreferenceServices(HelpHomeDbContext helpHomeDbContext, IMapper mapper, ILog logger)
        {
            _context = helpHomeDbContext;
            _mapper = mapper;
            _logger = logger;
        }


        public CarpetWashingPreferenceDto GetById(int offerentId, int preferenceId)
        {
            _logger.Info($"Cleaning offer with id: {preferenceId} GET action invoked");
            var offerent = _context.Oferrents.FirstOrDefault(u => u.Id == offerentId);
            if (offerent is null)
            {
                throw new NotFoundExeption("Offerent is not found");
            }
            var preference = _context.CarpetWashingPreferences.Include(x => x.Location).FirstOrDefault(x => x.OfferentId == offerentId && x.Id == preferenceId);
            if (preference is null || preference.OfferentId != offerentId)
            {
                throw new NotFoundExeption("Offer is not found");
            }

            var preferenceDto = _mapper.Map<CarpetWashingPreferenceDto>(preference);
            return preferenceDto;
        }

        public List<CarpetWashingPreferenceDto> GetAll(int offerentId)
        {

            _logger.Info($"All CarpetWashing offers from Seeker with id: {offerentId} GET All action invoked");
            var offerent = _context.Oferrents.Include(x => x.CarpetWashingPreferences).FirstOrDefault(u => u.Id == offerentId);
            if (offerent is null)
            {
                throw new NotFoundExeption("Seeker is not found");
            }
            
            var allPreferences = _context.CarpetWashingPreferences.Include(x=>x.Location).Where(x => x.OfferentId == offerentId);

            var allPreferencesDto = _mapper.Map<List<CarpetWashingPreferenceDto>>(allPreferences);
            return allPreferencesDto;
        }

        //public List<OfferDto> GetAllOffers()
        //{
        //    _logger.Info($"All CarpetWashing offers from Seeker with id: {offerentId} GET All action invoked");
        //    var offerent = _context.Oferrents.Include(x => x.CleaningPreferences).FirstOrDefault(u => u.Id == offerentId);
        //    if (offerent is null)
        //    {
        //        throw new NotFoundExeption("Seeker is not found");
        //    }

        //    var allPreferences = _context.CleaningPreferences.Include(x => x.Location).Where(x => x.OfferentId == offerentId);

        //    var allPreferencesDto = _mapper.Map<List<CleaningPreferenceDto>>(allPreferences);
        //    return allPreferencesDto;
        //}
    }

}