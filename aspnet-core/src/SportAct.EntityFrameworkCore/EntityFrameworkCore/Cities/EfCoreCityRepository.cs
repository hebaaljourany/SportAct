using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SportAct.Cities
{
    public class EfCoreCityRepository
        : EfCoreRepository<SportActDbContext, City, Guid>,
            ICityRepository
    {
        public EfCoreCityRepository(
            IDbContextProvider<SportActDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<City> FindByCityNameAsync(string cityname)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(city => city.CityName == cityname);
        }

        public async Task<List<City>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    city => city.CityName.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
