using Domain.Models;

namespace Data.Services
{
    public interface IAccountServices
    {
        void RegisterSeeker(RegisterSeekerDto dto);
        void RegisterOfferent(RegisterOfferentDto dto);
    }
}