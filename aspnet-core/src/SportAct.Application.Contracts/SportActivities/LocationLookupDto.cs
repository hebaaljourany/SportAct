using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.SportActivities
{
    public class LocationLookupDto : EntityDto<Guid>
    {
        public string LocationName { get; set; }
    }
}
