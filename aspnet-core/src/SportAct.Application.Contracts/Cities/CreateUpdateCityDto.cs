using System;
using System.ComponentModel.DataAnnotations;

namespace SportAct.Cities
{
    public class CreateUpdateCityDto
    {
        [Required]
        public string CityName { get; set; }
        //public List<Location> CityLocations { get; set; }
    }
}