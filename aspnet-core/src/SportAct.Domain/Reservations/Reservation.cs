using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SportAct.Reservations

{
    public class Reservation : AuditedAggregateRoot<Guid>
    {


        public int Participants { get; set; }
        public Guid SportActivityId { get; set; }
        public Guid ClientId { get; set; }


    }
}
