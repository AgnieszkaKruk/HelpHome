using Domain.Models;

namespace Data.Services
{
    public interface IWindowsCleaningPreferenceServices
    {
        //int CreateOffer(CreateCleaningDto dto, int seekerId);
        List<WindowsCleaningPreferenceDto> GetAll(int offerentId);
        // List<OfferDto> GetAllOffers();
        WindowsCleaningPreferenceDto GetById(int offerentId, int preferenceId);
    }
}
