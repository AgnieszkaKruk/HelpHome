using Data.Services;
using Domain.Entities.OfferentPreferences;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/Offerents/{offerentId}/carpetwashingpreferences")]
    [ApiController]
    public class CarpetWashingPreferenceController : Controller
    {

            private readonly ICarpetWashingPreferenceServices _carpetWashingPreferenceServices;

            public CarpetWashingPreferenceController(ICarpetWashingPreferenceServices carpetWashingPreferenceServices)
            {
            _carpetWashingPreferenceServices = carpetWashingPreferenceServices;

            }

            //[HttpPost]
            //public ActionResult AddOffer([FromRoute] int offerentId, [FromBody] CreateCleaningDto dto)
            //{
            //    var newOfferId = _cleaningPreferenceServices.CreateOffer(dto, seekerId);
            //    return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
            //}

            [HttpGet("{preferenceId}")]
            public ActionResult<CarpetWashingPreferenceDto> GetById([FromRoute] int offerentId, [FromRoute] int preferenceId)
            {
                var preference = _carpetWashingPreferenceServices.GetById(offerentId, preferenceId);
                return Ok(preference);
            }

            [HttpGet]
            public ActionResult<IEnumerable<CarpetWashingPreferenceDto>> GetAll([FromRoute] int offerentId)
            {
                var allpreferences = _carpetWashingPreferenceServices.GetAll(offerentId);
                return Ok(allpreferences);
            }

        
    }
}
