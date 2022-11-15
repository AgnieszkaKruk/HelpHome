using Domain.Models;

namespace Domain.Services
{
    public interface IOfferentServices
    {
        int CreateOfferent(CreateOfferentDto dto);
        IEnumerable<OfferentDto> GetAllWithPreferences();
        OfferentDto GetById(int id);
        bool Delete(int id);
        bool Update(CreateOfferentDto dto, int id);
        IEnumerable<OfferentDto> GetAll();
    }
}