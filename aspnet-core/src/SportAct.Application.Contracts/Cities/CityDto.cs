using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Cities
{
    public class CityDto : AuditedEntityDto<Guid>
    {
        public string CityName { get; set; }
        //public List<Location> CityLocations { get; set; }
    }
}
