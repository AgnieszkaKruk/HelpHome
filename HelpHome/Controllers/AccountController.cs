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
        [HttpPost("register/seeker")]
        public ActionResult RegisterSeeker([FromBody] RegisterSeekerDto dto)
        {
            _accountServices.RegisterSeeker(dto);
            return Ok();
        }
        [HttpPost("register/offerent")]
        public ActionResult RegisterOfferent([FromBody] RegisterOfferentDto dto)
        {
            _accountServices.RegisterOfferent(dto);
            return Ok();
        }

    }
}
