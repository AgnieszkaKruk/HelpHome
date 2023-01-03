using Data.Migrations;
using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using Domain.Services;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Data.Services
{
    
    public class AllOffersServices 
    {
        public const int DefaultOffersPageNumber = 1;
        public const int DefaultOffersPageSize = 20;
        public HelpHomeDbContext _context;
        

        public readonly ICarpetWashingServices _carpetServices;
        public readonly ICleaningServices _cleaningServices;
        public readonly IWindowsCleaningServices _windowsCleaningServices;

        public AllOffersServices(HelpHomeDbContext helpHomeDbContext) 
        {
            _context = helpHomeDbContext;

        }


        public async Task<(IReadOnlyList<OfferDto>, PaginationMetadata)> GetAllOffersAsync(
        string? name = null,
        string? city = null,
        Regularity? regularity = null,
        int pageNumber = DefaultOffersPageNumber,
        int pageSize = DefaultOffersPageSize)
        {
            Expression<Func<OfferDto, bool>>? filter = null;
            Func<IQueryable<OfferDto>, IOrderedQueryable<OfferDto>>? orderBy = (q) => q.OrderBy(q => q.Id);

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter = filter is null ? q => q.Name == name : filter.And(q => q.Name == name);
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                filter = filter is null ? q => q.City == city : filter.And(q => q.City == city);
            }

            if (regularity != null)
            {
                filter = filter is null ? q => q.Regularity == regularity : filter.And(q => q.Regularity == regularity);
            }

            orderBy = q => q.OrderBy(q => q.Id);

            return await GetOffersAsync(
            filter: filter,
            orderBy: orderBy,
            pageNumber: pageNumber,
            pageSize: pageSize);


        }

        //stworzyc widok zmapowac do widoku
       
        public async Task<(IReadOnlyList<OfferDto>, PaginationMetadata)> GetOffersAsync(
        Expression<Func<OfferDto, bool>>? filter = null,
        Func<IQueryable<OfferDto>, IOrderedQueryable<OfferDto>>? orderBy = null,
        int pageNumber = default, int pageSize = default)
        {

            var carpetoffers = _carpetServices.GetAllOffers();
            var cleaning = _cleaningServices.GetAllOffers();
            var windows = _windowsCleaningServices.GetAllOffers();

            carpetoffers.AddRange(cleaning);
            carpetoffers.AddRange(windows);

            IQueryable<OfferDto> query = (IQueryable<OfferDto>)carpetoffers;
            

            if (filter is not null)
            {
                query = query.Where(filter);
            }
            var totalItemCount = await query.CountAsync();
            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);
            if (orderBy is not null)
            {
                query = orderBy(query);
            }

            var result = await query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (result.AsReadOnly(), paginationMetadata);
        }


    }
}
