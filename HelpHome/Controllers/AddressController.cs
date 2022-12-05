using Data.Services;
using Domain.Entities;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [Route("api/{offertype}/{offerId}/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressServices _addressServices;
        public AddressController(IAddressServices addressServices)
        {
            _addressServices = addressServices;

        }
        [HttpGet]
        public ActionResult<Address> GetById([FromRoute] int offerId, string offertype)
        {
            var address = _addressServices.GetById(offerId,offertype);
            return Ok(address);
        }
       
    }
}
