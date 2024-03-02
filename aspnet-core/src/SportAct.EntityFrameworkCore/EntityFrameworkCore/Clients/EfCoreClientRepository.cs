using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SportAct.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SportAct.Domain
{
    public class EfCoreClientRepository 
        : EfCoreRepository<SportActDbContext, Client, Guid>,
        IClientRepository
    {
        public EfCoreClientRepository(IDbContextProvider<SportActDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task<Client> GetByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        // Additional custom repository methods...
    }
}
