using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;

namespace SportAct.Locations

{
    public class Location : AuditedAggregateRoot<Guid>
    {
        
       
        public string LocationName { get; set; }
        public Guid CityId { get; set; }

        ////////////////
        private Location()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Location(
            Guid id,
            [NotNull] string locationname)
            : base(id)
        {
            SetName(locationname);

        }

        internal Location ChangeName([NotNull] string locationname)
        {
            SetName(locationname);
            return this;
        }

        private void SetName([NotNull] string locationname)
        {
            LocationName = Check.NotNullOrWhiteSpace(
                locationname,
                nameof(locationname),
                maxLength: LocationConsts.MaxLocationNameLength
            );
        }


    }
}
