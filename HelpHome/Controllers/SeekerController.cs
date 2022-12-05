using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{

    [Route("api/seekers")]
    [ApiController]
    public class SeekerController : Controller
    {
        private readonly ISeekerServices _seekerServices;

        public SeekerController(ISeekerServices seekerServices)
        {
            _seekerServices = seekerServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeekerDto>> GetAllWithOffers()
        {
            var seekers = _seekerServices.GetAllWithOffers();
            return Ok(seekers);
        }

        [HttpGet("{id}")]

        public ActionResult<SeekerDto> GetById([FromRoute] int id)
        {
            var seeker = _seekerServices.GetById(id);
            return Ok(seeker);
        }

        //[HttpPost]

        //public ActionResult CreateSeeker([FromBody] CreateSeekerDto dto)
        //{
        //    var seekerId = _seekerServices.CreateSeeker(dto);
        //    return Created($"/api/Seekers/{seekerId}", null);

        //}

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete([FromRoute] int id)
        {
            _seekerServices.Delete(id);
            return NoContent();

        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Update([FromBody] CreateSeekerDto dto, [FromRoute] int id)
        {
             _seekerServices.Update(dto, id);   
            return Ok();
            
        }

    }
}
