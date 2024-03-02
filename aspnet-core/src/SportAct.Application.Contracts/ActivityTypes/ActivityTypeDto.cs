using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.ActivityTypes
{
    public class ActivityTypeDto : AuditedEntityDto<Guid>
    {
        public string ActivityTypeName { get; set; }
        //public List<SportActivity> SportActivitiesType { get; set; }
    }
}
