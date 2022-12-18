using AutoMapper;
using Data.Services;
using Domain.Entities.Utils;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/preferences")]
    public class AllPreferencesController : Controller
    {
        private const int DefaultOffersPageNumber = 1;
        private const int DefaultOffersPageSize = 10;
        private const int MaxOffersPageSize = 100;


        public readonly ICarpetWashingPreferenceServices _carpetPreferenceServices;
        public readonly ICleaningPreferencesServices _cleaningPreferenceServices;
        public readonly IWindowsCleaningPreferenceServices _windowsCleaningPreferenceServices;
        private readonly IMapper _mapper;

        public AllPreferencesController(IWindowsCleaningPreferenceServices windowsCleaningPreferenceServices, ICarpetWashingPreferenceServices carpetWashingPreferenceServices, ICleaningPreferencesServices cleaningPreferenceServices, IMapper mapper)
        {
            _carpetPreferenceServices = carpetWashingPreferenceServices;
            _cleaningPreferenceServices = cleaningPreferenceServices;
            _windowsCleaningPreferenceServices = windowsCleaningPreferenceServices;
            _mapper = mapper;
        }



        [HttpGet]

        public ActionResult<IEnumerable<OfferDto>> GetAll( 
        [FromQuery(Name = "filter_name")] string? name,
        [FromQuery(Name = "filter_city")] string? city,
        [FromQuery(Name = "filter_regularity")] Regularity? regularity,
        [FromQuery] int pageNumber = DefaultOffersPageNumber,
        [FromQuery] int pageSize = DefaultOffersPageSize
        )

        {
            //var carpetPreferences = _carpetPreferenceServices.GetAllOffers(); // zmapowac do ofert ogolnej, nie pobierac szczegolow, offer DTO
            //var windowsPreferences = _windowsCleaningPreferenceServices.GetAllOffers();
            var cleaningPreferences = _cleaningPreferenceServices.GetAllOffers();

            //carpetoffers.AddRange(windowsoffers);
            //carpetoffers.AddRange(cleaningoffers);
            return Ok(cleaningPreferences);

        }


    }
}
