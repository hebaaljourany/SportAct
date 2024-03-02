using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SportAct.Locations
{
    public class EfCoreLocationRepository
        : EfCoreRepository<SportActDbContext, Location, Guid>,
            ILocationRepository
    {
        public EfCoreLocationRepository(
            IDbContextProvider<SportActDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Location> FindByLocationNameAsync(string locationname)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(location => location.LocationName == locationname);
        }

        public async Task<List<Location>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    location => location.LocationName.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
