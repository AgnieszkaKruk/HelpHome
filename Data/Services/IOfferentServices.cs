using Domain.Models;

namespace Domain.Services
{
    public interface IOfferentServices
    {
        int CreateOfferent(CreateOfferentDto dto);
        IEnumerable<OfferentDto> GetAllWithPreferences();
        OfferentDto GetById(int id);
        void Delete(int id);
        void Update(CreateOfferentDto dto, int id);
        IEnumerable<OfferentDto> GetAll();
    }
}