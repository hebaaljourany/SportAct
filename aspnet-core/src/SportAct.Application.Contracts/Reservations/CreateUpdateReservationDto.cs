using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.Reservations
{
    public class CreateUpdateReservationDto
    {
       // [Required]
       // public int Participants { get; set; }
        public Guid SportActivityId { get; set; }
        public Guid ClientId { get; set; }


    }
}