using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;


namespace SportAct.Cities

{
    public class City : AuditedAggregateRoot<Guid>
    {
     
     
        public string CityName { get; set; }
        //public List<Location> CityLocations { get; set; }
        private City()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal City(
            Guid id,
            [NotNull] string cityname)
            : base(id)
        {
            SetName(cityname);
           
        }

        internal City ChangeName([NotNull] string cityname)
        {
            SetName(cityname);
            return this;
        }

        private void SetName([NotNull] string cityname)
        {
            CityName = Check.NotNullOrWhiteSpace(
                cityname,
                nameof(cityname),
                maxLength: CityConsts.MaxCityNameLength
            );
        }


    }
}
