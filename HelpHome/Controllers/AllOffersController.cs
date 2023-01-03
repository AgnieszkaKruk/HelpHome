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

        private const int DefaultOffersPageNumber = 1;
        private const int DefaultOffersPageSize = 10;
        private const int MaxOffersPageSize = 100;
        public readonly AllOffersServices _allOffersServices;

        //public readonly ICarpetWashingServices _carpetServices;
        //public readonly ICleaningServices _cleaningServices;
        //public readonly IWindowsCleaningServices _windowsCleaningServices;

        //private readonly IMapper _mapper;

        //public AllOffersController(IWindowsCleaningServices windowsCleaningServices, ICarpetWashingServices carpetWashingServices, ICleaningServices cleaningServices, IMapper mapper)
        //{
        //    _carpetServices = carpetWashingServices;
        //    _cleaningServices = cleaningServices;
        //    _windowsCleaningServices = windowsCleaningServices;
        //    _mapper = mapper;
        //}

        public AllOffersController(AllOffersServices services)
        {
            _allOffersServices = services;
        }



        [HttpGet]

        public async Task<ActionResult<IEnumerable<OfferDto>>> GetAllOffers(
            [FromQuery(Name = "filter_name")] string? name,
            [FromQuery(Name = "filter_city")] string? city,
            [FromQuery(Name = "filter_regularity")] Regularity? regularity,
            [FromQuery] int pageNumber = DefaultOffersPageNumber,
            [FromQuery] int pageSize = DefaultOffersPageSize

            )
        //{
        //    var carpetoffers = _carpetServices.GetAllOffers();
        //    var cleaning = _cleaningServices.GetAllOffers();
        //    var windows = _windowsCleaningServices.GetAllOffers();

        //    carpetoffers.AddRange(cleaning);
        //    carpetoffers.AddRange(windows);
        //    return Ok(carpetoffers);
        //}

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

            var (offers, paginationMetadata) = await _allOffersServices.GetAllOffersAsync(name,city,regularity,pageNumber,pageSize);
            
            return Ok(offers);
        }





        //}
    }
}
