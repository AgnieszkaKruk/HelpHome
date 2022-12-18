using Domain.Models;

namespace Domain.Services
{
    public interface ICarpetWashingServices
    {
        int CreateOffer(CreateCarpetWashingDto dto, int seekerId);
        List<CarpetWashingDto> GetAll(int seekerId);

        List<OfferDto> GetAllOffers();
        CarpetWashingDto GetById(int seekerId, int offerId);
    }
}