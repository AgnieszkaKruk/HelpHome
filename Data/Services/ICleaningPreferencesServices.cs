using Domain.Models;

namespace Data.Services
{
    public interface ICleaningPreferencesServices
    {
       //int CreateOffer(CreateCleaningDto dto, int offerentId);
        public List<CleaningPreferenceDto> GetAll(int offerentId);
        public CleaningPreferenceDto GetById(int offerentId, int preferenceId);
        public List<PreferenceDto> GetAllOffers();
    }
}
