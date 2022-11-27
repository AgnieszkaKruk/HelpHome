using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route ("api/windowscleaningoffers")]
    [ApiController]
    public class WindowsCleaningController : ControllerBase
    {
        private readonly IWindowsCleaningServices _windowsCleaningServices;

        public WindowsCleaningController(IWindowsCleaningServices windowsCleaningServices)
        {
            _windowsCleaningServices= windowsCleaningServices;
        }

        [HttpPost]
        public ActionResult AddOffer ([FromRoute] int seekerId,[FromBody] CreateWindowsCleaningDto dto)
        {
           var newOfferId = _windowsCleaningServices.CreateOffer(dto, seekerId);
            return Created($"api/seeker/{seekerId}/offers/{newOfferId}", null);
        }

        [HttpGet("{offerId}")]
        public ActionResult<WindowsCleaningDto> GetById([FromRoute] int seekerId, [FromRoute] int id)
        {
            var offer = _windowsCleaningServices.GetById(seekerId, id);
            return Ok(offer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<WindowsCleaningDto>> GetAll([FromRoute] int seekerId)
        {
            var alloffers = _windowsCleaningServices.GetAll(seekerId);
            return Ok(alloffers);
        }
        
    }
}
