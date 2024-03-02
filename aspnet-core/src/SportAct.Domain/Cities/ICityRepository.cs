using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Cities
{
    public interface ICityRepository : IRepository<City, Guid>
    {
        Task<City> FindByCityNameAsync(string cityname);

        Task<List<City>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
