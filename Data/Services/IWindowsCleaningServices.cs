using Domain.Models;

namespace Domain.Services
{
    public interface IWindowsCleaningServices
    {
        int CreateOffer(CreateWindowsCleaningDto dto, int seekerId);
        List<WindowsCleaningDto> GetAll(int seekerId);
        List<OfferDto> GetAllOffers();
        WindowsCleaningDto GetById(int seekerId, int offerId);
    }
}