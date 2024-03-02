using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.SportActivities
{
    public class SportActivityDto : AuditedEntityDto<Guid>
    {
       
        public string ActivityName { get; set; }
        public int Capacity { get; set; }
        public int Cost { get; set; }
        public int MinimumAge { get; set; }

        public int MaximumAge { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndedTime { get; set; }
        public string Description { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

    }
}
