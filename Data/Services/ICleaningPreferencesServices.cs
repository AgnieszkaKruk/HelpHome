using Domain.Models;

namespace Data.Services
{
    public interface ICleaningPreferencesServices
    {
       // int CreateOffer(CreateCleaningDto dto, int offerentId);
        List<CleaningPreferenceDto> GetAll(int offerentId);
        CleaningPreferenceDto GetById(int offerentId, int preferenceId);
    }
}
