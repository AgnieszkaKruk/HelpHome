using AutoMapper;
using Domain.Entities;
using Domain.Entities.OfferentPreferences;
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
            CreateMap<CreateSeekerDto, Seeker>();           
            CreateMap<CreateCarpetWashingDto, CarpetWashing> ();
            CreateMap<CarpetWashing, CarpetWashingDto>();
            CreateMap<Cleaning, CleaningDto>();
            CreateMap<WindowsCleaning, WindowsCleaningDto>();
            CreateMap<WindowsCleaning,OfferDto >();
            CreateMap<CarpetWashing, OfferDto>();
            CreateMap<Cleaning, OfferDto>();
            CreateMap<CleaningPreference, OfferDto>();

            CreateMap<CleaningPreference, CleaningPreferenceDto>();
            CreateMap<CarpetWashingPreference, CarpetWashingPreferenceDto>();
            CreateMap<WindowsCleaningPreference, WindowsCleaningPreferenceDto>();

            CreateMap<CleaningPreference, PreferenceDto>();
            CreateMap<CarpetWashingPreference, PreferenceDto>();
            CreateMap<WindowsCleaningPreference, PreferenceDto>();

        }
    }
}
