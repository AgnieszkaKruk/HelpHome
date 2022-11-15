using Domain.Models;

namespace Domain.Services
{
    public interface ICleaningServices
    {
        int CreateOffer(CreateCleaningDto dto, int seekerId);
        List<CleaningDto> GetAll(int seekerId);
        CleaningDto GetById(int seekerId, int offerId);
    }
}