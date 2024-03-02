using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Locations
{
    public class LocationDto : AuditedEntityDto<Guid>
    {
        public string LocationName { get; set; }
        public Guid CityId { get; set; }
        public string CityName { get; set; }
        // public List<SportActivity> SportActivitiesLocation { get; set; }

        //[ForeignKey("CityId")]

        //public int CityId { get; set; }
        // public City City { get; set; }
    }
}
