using AutoMapper;
using Data.Services;
using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class AllOffersController : ControllerBase
    {
        public readonly ICarpetWashingServices _carpetServices;
        public readonly ICleaningServices _cleaningServices;    
        public readonly IWindowsCleaningServices _windowsCleaningServices;
        private readonly IMapper _mapper;

        public AllOffersController(IWindowsCleaningServices windowsCleaningServices, ICarpetWashingServices carpetWashingServices,ICleaningServices cleaningServices, IMapper mapper)
        {
            _carpetServices = carpetWashingServices;
            _cleaningServices = cleaningServices;
            _windowsCleaningServices = windowsCleaningServices;
            _mapper = mapper;    
        }



        [HttpGet]
        
        public ActionResult<IEnumerable<OfferDto>> GetAll() 

        {
            var carpetoffers =  _carpetServices.GetAllOffers(); 
            var cleaning = _cleaningServices.GetAllOffers();
            var windows = _windowsCleaningServices.GetAllOffers();

            carpetoffers.AddRange(cleaning);
            carpetoffers.AddRange(windows);
            return Ok(carpetoffers);
        }
        

    }
}
