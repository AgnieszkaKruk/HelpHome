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
    public class AllPreferencesController : ControllerBase
    {
        


        public readonly ICarpetWashingPreferenceServices _carpetPreferenceServices;
        public readonly ICleaningPreferencesServices _cleaningPreferenceServices;
        public readonly IWindowsCleaningPreferenceServices _windowsCleaningPreferenceServices;

        public AllPreferencesController(IWindowsCleaningPreferenceServices windowsCleaningPreferenceServices, ICarpetWashingPreferenceServices carpetWashingPreferenceServices, ICleaningPreferencesServices cleaningPreferenceServices, IMapper mapper)
        {
            _carpetPreferenceServices = carpetWashingPreferenceServices;
            _cleaningPreferenceServices = cleaningPreferenceServices;
            _windowsCleaningPreferenceServices = windowsCleaningPreferenceServices;
            
        }



        [HttpGet]

        public ActionResult<IEnumerable<PreferenceDto>> GetAll()

        {
            var carpetPreferences = _carpetPreferenceServices.GetAllOffers(); // zmapowac do ofert ogolnej, nie pobierac szczegolow, offer DTO
            var windowsPreferences = _windowsCleaningPreferenceServices.GetAllOffers();
            var cleaningPreferences = _cleaningPreferenceServices.GetAllOffers();

            carpetPreferences.AddRange(windowsPreferences);
            carpetPreferences.AddRange(cleaningPreferences);
            return Ok(carpetPreferences);

        }


    }
}
