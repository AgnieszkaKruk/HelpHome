using Domain.Models;

namespace Data.Services
{
    public interface ICarpetWashingPreferenceServices
    {
        
        //int CreateOffer(CreateCleaningDto dto, int seekerId);
        List<CarpetWashingPreferenceDto> GetAll(int offerentId);
        // List<OfferDto> GetAllOffers();
        CarpetWashingPreferenceDto GetById(int offerentId, int preferenceId);
        
    }
}
