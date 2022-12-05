using Domain.Models;

namespace Domain.Services
{
    public interface ICarpetWashingServices
    {
        int CreateOffer(CreateCarpetWashingDto dto, int seekerId);
        List<CarpetWashingDto> GetAll(int seekerId);
        CarpetWashingDto GetById(int seekerId, int offerId);
        void Delete(int id);
    }
}