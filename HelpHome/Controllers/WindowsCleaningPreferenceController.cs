using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/Offerents/{offerentId}/windowscleaningpreferences")]
    [ApiController]
    public class WindowsCleaningPreferenceController : Controller
    {

        private readonly IWindowsCleaningPreferenceServices _windowsCleaningPreferenceServices;

        public WindowsCleaningPreferenceController(IWindowsCleaningPreferenceServices windowsCleaningPreferenceServices)
        {
            _windowsCleaningPreferenceServices = windowsCleaningPreferenceServices;

        }

        //[HttpPost]
        //public ActionResult AddOffer([FromRoute] int offerentId, [FromBody] CreateCleaningDto dto)
        //{
        //    var newOfferId = _cleaningPreferenceServices.CreateOffer(dto, seekerId);
        //    return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
        //}

        [HttpGet("{preferenceId}")]
        public ActionResult<WindowsCleaningPreferenceDto> GetById([FromRoute] int offerentId, [FromRoute] int preferenceId)
        {
            var preference = _windowsCleaningPreferenceServices.GetById(offerentId, preferenceId);
            return Ok(preference);
        }

        [HttpGet]
        public ActionResult<IEnumerable<WindowsCleaningPreferenceDto>> GetAll([FromRoute] int offerentId)
        {
            var allpreferences = _windowsCleaningPreferenceServices.GetAll(offerentId);
            return Ok(allpreferences);
        }


    }
}
