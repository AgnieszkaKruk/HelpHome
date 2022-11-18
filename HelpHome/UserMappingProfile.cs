using AutoMapper;
using Domain.Entities;
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

            CreateMap<Offerent, OfferentDto>();
                //.ForMember(c => c.City, d => d.MapFrom(s => s.Addresses.City))
                //.ForMember(c => c.Street, d => d.MapFrom(s => s.Addresses.Street))
                //.ForMember(c => c.PostalCode, d => d.MapFrom(s => s.Addresses.PostalCode));
            CreateMap<CreateSeekerDto, Seeker>();
                 //.ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
                 //{
                 //    City = dto.City,
                 //    PostalCode = dto.PostalCode,
                 //    Street = dto.Street
                 //}));
            CreateMap<CreateCarpetWashingDto, CarpetWashing> ();
            CreateMap<CarpetWashing, CarpetWashingDto>();
            CreateMap<Cleaning, CleaningDto>();
            CreateMap<WindowsCleaning, WindowsCleaningDto>();
        }
    }
}
