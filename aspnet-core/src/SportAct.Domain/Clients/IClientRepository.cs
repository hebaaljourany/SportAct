using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Domain
{
    public interface IClientRepository : IRepository<Client, Guid>
    {
        Task<Client> GetByUserIdAsync(Guid userId);
    }
}
