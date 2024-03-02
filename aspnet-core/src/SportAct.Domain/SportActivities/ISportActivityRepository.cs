using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.SportActivities
{
    public interface ISportActivityRepository : IRepository<SportActivity, Guid>
    {
        Task<SportActivity> FindByActivityNameAsync(string activityname);

        Task<List<SportActivity>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
