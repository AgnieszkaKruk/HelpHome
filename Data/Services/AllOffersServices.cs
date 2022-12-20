using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Data.Services
{
    
    public class AllOffersServices : IAllOffersServices<OfferDto>
    {
        public const int DefaultOffersPageNumber = 1;
        public const int DefaultOffersPageSize = 20;
     
        public AllOffersServices(HelpHomeDbContext helpHomeDbContext) : base(helpHomeDbContext)
        {
            
        }


        public async Task<(IReadOnlyList<OfferDto>, PaginationMetadata)> GetOffersAsync(
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
                filter = filter is null ? q => q.Name == name : filter;
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                filter = filter is null ? q => q.City == city : filter;
            }

            if (regularity != null)
            {
                filter = filter is null ? q => q.Regularity == regularity : filter;
            }

            orderBy = q => q.OrderBy(q => q.Id);

            return await GetOffersAsync(
            filter: filter,
            orderBy: orderBy,
            pageNumber: pageNumber,
            pageSize: pageSize);


        }


    }
}
