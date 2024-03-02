using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Domain
{
    public class ClientDto : AuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
       // public string UserName { get; set; }
       // public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string EmailAddress { get; set; }
        //public int MobileNumber { get; set; }
        // public List<Reservation> ClientReservations { get; set; }
    }
}
