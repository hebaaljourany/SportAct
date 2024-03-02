using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.Locations
{
    public class CreateUpdateLocationDto
    {
        [Required]
        public string LocationName { get; set; }
        public Guid CityId { get; set; }

        // public List<SportActivity> SportActivitiesLocation { get; set; }


        //[ForeignKey("CityId")]

        //public int CityId { get; set; }
        // public City City { get; set; }
    }
}