using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SportAct.SportActivities
{
    public class EfCoreSportActivityRepository
        : EfCoreRepository<SportActDbContext, SportActivity, Guid>,
            ISportActivityRepository
    {
        public EfCoreSportActivityRepository(
            IDbContextProvider<SportActDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<SportActivity> FindByActivityNameAsync(string activityname)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(sportactivity => sportactivity.ActivityName == activityname);
        }

        public async Task<List<SportActivity>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    sportactivity => sportactivity.ActivityName.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
