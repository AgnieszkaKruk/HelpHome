using AutoMapper;
using Data;
using Domain.Models;
using Domain.Services;
using HelpHome.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/seekers")]
    public class SeekerController : Controller
    {
        private readonly ISeekerServices _seekerServices;

        public SeekerController(ISeekerServices seekerServices)
        {
            _seekerServices = seekerServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeekerDto>> GetAll()
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

        [HttpPost]

        public ActionResult CreateSeeker([FromBody] CreateSeekerDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var seekerId = _seekerServices.CreateSeeker(dto);

            return Created($"/api/Seekers/{seekerId}", null);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _seekerServices.Delete(id);

            return NoContent();

        }

        [HttpPut("{id}")]

        public ActionResult Update([FromBody] CreateSeekerDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _seekerServices.Update(dto, id);   
            return Ok();
            
        }

    }
}
