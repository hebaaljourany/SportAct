using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace SportAct.Domain

{
    public class Client : AuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
       
    }
}
