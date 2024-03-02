using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Locations
{
    public interface ILocationRepository : IRepository<Location, Guid>
    {
        Task<Location> FindByLocationNameAsync(string locationname);

        Task<List<Location>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
