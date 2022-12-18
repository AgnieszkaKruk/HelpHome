using AutoMapper;
using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class AllOffersController : Controller
    {
        private const int DefaultOffersPageNumber = 1;
        private const int DefaultOffersPageSize = 10;
        private const int MaxOffersPageSize = 100;


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
        
        public ActionResult<IEnumerable<OfferDto>> GetAll( //offer Dto
        [FromQuery(Name = "filter_name")] string? name,
        [FromQuery(Name = "filter_city")] string? city,
        [FromQuery(Name = "filter_regularity")] Regularity? regularity,
        [FromQuery] int pageNumber = DefaultOffersPageNumber,
        [FromQuery] int pageSize = DefaultOffersPageSize
        )

        {
            var carpetoffers = _carpetServices.GetAllOffers(); // zmapowac do ofert ogolnej, nie pobierac szczegolow, offer DTO
            var windowsoffers = _windowsCleaningServices.GetAllOffers();
            var cleaningoffers = _cleaningServices.GetAllOffers();

            carpetoffers.AddRange(windowsoffers);
            carpetoffers.AddRange(cleaningoffers);
            return Ok(carpetoffers);

        }
        

    }
}
