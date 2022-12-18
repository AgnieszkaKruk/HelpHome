using Data.Services;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/Offerents/{offerentId}/cleaningpreferences")]
    [ApiController]
    public class CleaningPreferenceController : ControllerBase
    {
        private readonly ICleaningPreferencesServices _cleaningPreferenceServices;

        public CleaningPreferenceController(ICleaningPreferencesServices cleaningPreferenceServices)
        {
            _cleaningPreferenceServices = cleaningPreferenceServices;

        }

        //[HttpPost]
        //public ActionResult AddOffer([FromRoute] int offerentId, [FromBody] CreateCleaningDto dto)
        //{
        //    var newOfferId = _cleaningPreferenceServices.CreateOffer(dto, seekerId);
        //    return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
        //}

        [HttpGet("{preferenceId}")]
        public ActionResult<CleaningPreferenceDto> GetById([FromRoute] int offerentId, [FromRoute] int preferenceId)
        {
            var preference = _cleaningPreferenceServices.GetById(offerentId, preferenceId);
            return Ok(preference);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CleaningPreferenceDto>> GetAll([FromRoute] int offerentId)
        {
            var allpreferences= _cleaningPreferenceServices.GetAll(offerentId);
            return Ok(allpreferences);
        }

    }
}
