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
            //CreateMap<CreateSeekerDto, Seeker>();           
            CreateMap<CreateCarpetWashingDto, CarpetWashing> ();
            CreateMap<CarpetWashing, CarpetWashingDto>();
            CreateMap<Cleaning, CleaningDto>();
            CreateMap<WindowsCleaning, WindowsCleaningDto>();
            CreateMap<CreateWindowsCleaningDto, WindowsCleaning>();
            CreateMap<CreateCleaningDto, Cleaning>();

        }
    }
}
