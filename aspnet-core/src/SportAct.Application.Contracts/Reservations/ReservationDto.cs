using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Reservations
{
    public class ReservationDto : AuditedEntityDto<Guid>
    {
        public int Participants { get; set; }
        public Guid SportActivityId { get; set; }
        public string ActivityName { get; set; }
        public Guid ClientId { get; set; }
        //public string ClientName { get; set; }
    }
}
