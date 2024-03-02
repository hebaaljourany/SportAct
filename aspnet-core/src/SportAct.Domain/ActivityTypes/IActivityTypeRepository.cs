using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.ActivityTypes
{
    public interface IActivityTypeRepository : IRepository<ActivityType, Guid>
    {
        Task<ActivityType> FindByActivityTypeNameAsync(string activitytypename);

        Task<List<ActivityType>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
