using AutoMapper;
using Domain.Models;
using HelpHome.Entities;
using HelpHome.Entities.OfferTypes;

namespace HelpHomeApi
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Seeker, SeekerDto>();

            CreateMap<Offerent, OfferentDto>()
                .ForMember(c => c.City, d => d.MapFrom(s => s.Address.City))
                .ForMember(c => c.Street, d => d.MapFrom(s => s.Address.Street))
                .ForMember(c => c.PostalCode, d => d.MapFrom(s => s.Address.PostalCode));
            CreateMap<CreateSeekerDto, Offerent>();
            CreateMap<CreateCarpetWashingDto, CarpetWashing> ();
            CreateMap<CarpetWashing, CarpetWashingDto>();
            CreateMap<Cleaning, CleaningDto>();
            CreateMap<WindowsCleaning, WindowsCleaningDto>();
        }
    }
}
