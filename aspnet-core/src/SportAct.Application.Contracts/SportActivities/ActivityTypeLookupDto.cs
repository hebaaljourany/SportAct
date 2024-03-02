using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.SportActivities
{
    public class ActivityTypeLookupDto : EntityDto<Guid>
    {
        public string ActivityTypeName { get; set; }
    }
}
