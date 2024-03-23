using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SportAct.Reservations
{
    public interface IReservationRepository : IRepository<Reservation, Guid>
    {

        Task<List<Reservation>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
