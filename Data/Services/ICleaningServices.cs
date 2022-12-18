using Domain.Models;

namespace Domain.Services
{
    public interface ICleaningServices
    {
        //int CreateOffer(CreateCleaningDto dto, int seekerId);
        List<CleaningDto> GetAll(int seekerId);
        List<OfferDto> GetAllOffers();
        CleaningDto GetById(int seekerId, int offerId);
    }
}