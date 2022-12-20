using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Data.Entity;
using System.Linq.Expressions;


namespace Data.Services
{
    public abstract class IAllOffersServices<T> where T : class
    {
        protected readonly HelpHomeDbContext _homeDbContext;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;

        public readonly ICarpetWashingServices _carpetServices;
        public readonly ICleaningServices _cleaningServices;
        public readonly IWindowsCleaningServices _windowsCleaningServices;
        public IAllOffersServices(HelpHomeDbContext context)
        {
            _homeDbContext=context;
            _dbSet = _homeDbContext.Set<T>();
        }

        public async Task<(IReadOnlyList<T>,PaginationMetadata)> GetOffersAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int pageNumber = default, int pageSize = default)
        {

            var carpetoffers = _carpetServices.GetAllOffers();
            var cleaning = _cleaningServices.GetAllOffers();
            var windows = _windowsCleaningServices.GetAllOffers();

            carpetoffers.AddRange(cleaning);
            carpetoffers.AddRange(windows);


            IQueryable<T> query = (IQueryable<T>)carpetoffers;

            if (filter is not null)
            {
                query=query.Where(filter);
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
