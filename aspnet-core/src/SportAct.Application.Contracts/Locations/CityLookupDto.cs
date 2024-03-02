using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Locations
{
    public class CityLookupDto : EntityDto<Guid>
    {
        public string CityName { get; set; }
    }
}