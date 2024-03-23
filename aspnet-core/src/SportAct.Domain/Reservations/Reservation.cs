using SportAct.Domain;
using SportAct.SportActivities;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace SportAct.Reservations

{
    public class Reservation : AuditedAggregateRoot<Guid>
    {


        //public int Participants { get; set; }
        public SportActivity SportActivity { get; set; }
        public Guid SportActivityId { get; set; }
        public Client Client { get; set; }
        public Guid ClientId { get; set; }


    }
}
