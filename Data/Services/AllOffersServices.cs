using Domain.Entities.OfferTypes;
using Domain.Entities.Utils;
using Domain.Models;
using System.Linq.Expressions;

namespace Data.Services
{
    
    public class AllOffersServices
    {
        public const int DefaultOffersPageNumber = 1;
        public const int DefaultOffersPageSize = 20;
        private readonly HelpHomeDbContext _context;
        public AllOffersServices(HelpHomeDbContext helpHomeDbContext)
        {
            _context = helpHomeDbContext;
        }


        //public async Task<(IReadOnlyList<OfferDto>, PaginationMetadata)> GetOffersAsync(
        //string? name = null,
        //string? city = null,
        //Regularity? regularity = null,
        //int pageNumber = DefaultOffersPageNumber,
        //int pageSize = DefaultOffersPageSize)
        //{
        //    Expression<Func<OfferDto, bool>>? filter = null;
        //    Func<IQueryable<OfferDto>, IOrderedQueryable<OfferDto>>? orderBy = (q) => q.OrderBy(q => q.Id);

        //    if (!string.IsNullOrWhiteSpace(name))
        //    {
        //        filter = filter is null ? q => q.Name == name : filter;
        //    }

        //    if (!string.IsNullOrWhiteSpace(city))
        //    {
        //        filter = filter is null ? q => q.City == city : filter;
        //    }

        //    if (regularity !=null)
        //    {
        //        filter = filter is null ? q => q.Regularity == regularity : filter;
        //    }

        //    orderBy = q => q.OrderBy(q => q.Id);

        //    return await GetAsync(
        //        filter: filter,
        //        orderBy: orderBy,
        //        pageNumber: pageNumber,
        //        pageSize: pageSize);
        //}

        //public async Task<(IReadOnlyList<T>, PaginationMetadata)> GetAsync(
        //Expression<Func<T, bool>>? filter = null,
        //Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        //string? includeProperties = null,
        //int pageNumber = default, int pageSize = default)
        //{
        //    IQueryable<T> query = _dbSet.AsNoTracking();

        //    if (filter is not null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    if (!string.IsNullOrWhiteSpace(includeProperties))
        //    {
        //        foreach (var includeProperty in
        //                 includeProperties.Split(
        //                     new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }

        //    var totalItemCount = await query.CountAsync();
        //    var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        //    if (orderBy is not null)
        //    {
        //        query = orderBy(query);
        //    }

        //    var result = await query
        //        .Skip(pageSize * (pageNumber - 1))
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return (result.AsReadOnly(), paginationMetadata);
        //}
    }
}
