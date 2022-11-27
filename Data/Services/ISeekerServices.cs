using Domain.Models;

namespace Domain.Services
{
    public interface ISeekerServices
    {
        int CreateSeeker(CreateSeekerDto dto);
        void Delete(int id);
        IEnumerable<SeekerDto> GetAll();
        IEnumerable<SeekerDto> GetAllWithOffers();
        SeekerDto GetById(int id);
        void Update(CreateSeekerDto dto, int id);
    }
}