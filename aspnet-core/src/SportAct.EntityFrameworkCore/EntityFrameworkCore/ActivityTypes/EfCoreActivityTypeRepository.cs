using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SportAct.ActivityTypes
{
    public class EfCoreActivityTypeRepository
        : EfCoreRepository<SportActDbContext, ActivityType, Guid>,
            IActivityTypeRepository
    {
        public EfCoreActivityTypeRepository(
            IDbContextProvider<SportActDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<ActivityType> FindByActivityTypeNameAsync(string activitytypename)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(activitytype => activitytype.ActivityTypeName == activitytypename);
        }

        public async Task<List<ActivityType>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    activitytype => activitytype.ActivityTypeName.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
