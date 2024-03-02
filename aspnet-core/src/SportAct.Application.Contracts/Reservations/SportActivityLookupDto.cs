using System;
using Volo.Abp.Application.Dtos;

namespace SportAct.Reservations
{
    public class SportActivityLookupDto : EntityDto<Guid>
    {
        public string ActivityName { get; set; }
    }
}