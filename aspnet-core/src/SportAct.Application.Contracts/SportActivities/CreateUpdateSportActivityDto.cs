using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.SportActivities
{
    public class CreateUpdateSportActivityDto
    {
        [Required]
        public string ActivityName { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int MinimumAge { get; set; }
        [Required]

        public int MaximumAge { get; set; }
        [Required]

        public DateTime StartedTime { get; set; }
        [Required]

        public DateTime EndedTime { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid LocationId { get; set; }
        public Guid ActivityTypeId { get; set; }


        //public List<Reservation> SportActivitytReservations { get; set; }
        //[ForeignKey("LocatioId")]
        //public int LocationId { get; set; }
        //public Location Location { get; set; }

        //[ForeignKey("ActivityTypeId")]
        //public int ActivityTypeId { get; set; }
        //public ActivityType ActivityType { get; set; }
    }
}