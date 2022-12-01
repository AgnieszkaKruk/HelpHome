using Data.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase

    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;

        }
        [HttpPost("seeker/register")]
        public ActionResult RegisterSeeker([FromBody] RegisterSeekerDto dto)
        {
            _accountServices.RegisterSeeker(dto);
            return Ok();
        }
        [HttpPost("offerent/register")]
        public ActionResult RegisterOfferent([FromBody] RegisterOfferentDto dto)
        {
            _accountServices.RegisterOfferent(dto);
            return Ok();
        }

        [HttpPost("login")]
        public ActionResult GenerateJwt(LoginDto dto)
        {
           var token = _accountServices.GenerateJwt(dto);
            return Ok(token);
        }

    }
}
