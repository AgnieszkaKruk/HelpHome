using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route ("api/Seekers/{seekerId}/cleaningoffers")]
    [ApiController]
    public class CleaningController : ControllerBase
    {
        private readonly ICleaningServices _cleaningServices;

        public CleaningController(ICleaningServices cleaningServices)
        {
            _cleaningServices = cleaningServices;

        }

        [HttpPost]
       // [Authorize(Roles = "Seeker")]
        public ActionResult AddOffer ([FromRoute] int seekerId,[FromBody] CreateCleaningDto dto)
        {
           var newOfferId = _cleaningServices.CreateOffer(dto, seekerId);
            return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
        }

        [HttpGet("{offerId}")]
        public ActionResult<CleaningDto> GetById([FromRoute] int seekerId, [FromRoute] int offerId)
        {
            var offer = _cleaningServices.GetById(seekerId, offerId);
            return Ok(offer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CleaningDto>> GetAll([FromRoute] int seekerId)
        {
            var alloffers = _cleaningServices.GetAll(seekerId);
            return Ok(alloffers);
        }

        [HttpDelete("{offerId}")]
        [Authorize]
        public ActionResult Delete([FromRoute] int offerId)
        {
            _cleaningServices.Delete(offerId);
            return NoContent();
        }

    }
}
