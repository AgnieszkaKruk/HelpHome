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
    [Route("api/offerents")]
    public class OferrentController : Controller
    {
        private readonly IOfferentServices _offerentServices;

        public OferrentController(IOfferentServices offerentServices)
        {
            _offerentServices = offerentServices;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfferentDto>> GetAllWithPreferences()
        {
            var offerents = _offerentServices.GetAllWithPreferences();
            return Ok(offerents);
        }

        [HttpGet("{id}")]

        public ActionResult<OfferentDto> GetById([FromRoute] int id)
        {
            var offerent = _offerentServices.GetById(id);
            return Ok(offerent);
        }

        [HttpPost]

        public ActionResult CreateOfferent([FromBody] CreateOfferentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var offerent = _offerentServices.CreateOfferent(dto);

            return Created($"/api/offerents/{offerent}", null);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
             _offerentServices.Delete(id); 
             return NoContent(); 
          
        }

        [HttpPut("{id}")]

        public ActionResult Update([FromBody] CreateOfferentDto dto,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
             _offerentServices.Update(dto, id);
             return Ok();
        }




    }
}
