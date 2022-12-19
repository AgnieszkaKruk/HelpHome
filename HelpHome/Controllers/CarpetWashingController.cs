using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route ("api/Seekers/{seekerId}/carpetwashingoffers")]
    [ApiController]
    public class CarpetWashingController : ControllerBase
    {
        private readonly ICarpetWashingServices _carpetServices;

        public CarpetWashingController(ICarpetWashingServices carpetServices)
        {
            _carpetServices = carpetServices;

        }

        [HttpPost]
        public ActionResult AddOffer ([FromRoute] int seekerId,[FromBody] CreateCarpetWashingDto dto)
        {
           var newOfferId =  _carpetServices.CreateOffer(dto, seekerId);
            return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
        }

        [HttpGet("{offerId}")]
        public ActionResult<CarpetWashingDto> GetById([FromRoute] int seekerId, [FromRoute] int offerId)
        {
            var offer = _carpetServices.GetById(seekerId, offerId);
            return Ok(offer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CarpetWashingDto>> GetAll([FromRoute] int seekerId)
        {
            var alloffers = _carpetServices.GetAll(seekerId);
            return Ok(alloffers);
        }

        

    }
}
