using AutoMapper;
using Data.Services;
using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace HelpHomeApi.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class AllOffersController : ControllerBase
    {

        private const int DefaultOffersPageNumber = 1;
        private const int DefaultOffersPageSize = 10;
        private const int MaxOffersPageSize = 100;

        public readonly ICarpetWashingServices _carpetServices;
        public readonly ICleaningServices _cleaningServices;    
        public readonly IWindowsCleaningServices _windowsCleaningServices;
        public readonly IAllOffersServices<OfferDto> _allOffersServices;
        private readonly IMapper _mapper;

        public AllOffersController(IWindowsCleaningServices windowsCleaningServices, ICarpetWashingServices carpetWashingServices,ICleaningServices cleaningServices, IMapper mapper)
        {
            _carpetServices = carpetWashingServices;
            _cleaningServices = cleaningServices;
            _windowsCleaningServices = windowsCleaningServices;
            _mapper = mapper;    
        }



        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<OfferDto>>> GetAllOffers(
            [FromQuery(Name ="filter_name")] string?name,
            [FromQuery(Name = "filter_city")] string? city,
            [FromQuery(Name = "filter_regularity")] Regularity? regularity,
            [FromQuery] int pageNumber = DefaultOffersPageNumber,
            [FromQuery] int pageSize = DefaultOffersPageSize

            ) 

        {
            if (pageNumber <= 0)
            {
                ModelState.AddModelError(nameof(pageNumber), "Page number should be positive number!");
                return BadRequest(ModelState);
            }

            if (pageSize > MaxOffersPageSize)
            {
                pageSize = MaxOffersPageSize;
            }

            var (offers, paginationMetadata) = await _allOffersServices.GetOffersAsync();
            return Ok(offers);  


            //var carpetoffers =  _carpetServices.GetAllOffers(); 
            //var cleaning = _cleaningServices.GetAllOffers();
            //var windows = _windowsCleaningServices.GetAllOffers();

            //carpetoffers.AddRange(cleaning);
            //carpetoffers.AddRange(windows);
            //return Ok(carpetoffers);
        }

        





    }
}
