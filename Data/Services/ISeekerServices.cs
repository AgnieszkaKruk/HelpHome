using Domain.Models;

namespace Domain.Services
{
    public interface ISeekerServices
    {
        int CreateSeeker(CreateSeekerDto dto);
        bool Delete(int id);
        IEnumerable<SeekerDto> GetAll();
        IEnumerable<SeekerDto> GetAllWithOffers();
        SeekerDto GetById(int id);
        bool Update(CreateSeekerDto dto, int id);
    }
}