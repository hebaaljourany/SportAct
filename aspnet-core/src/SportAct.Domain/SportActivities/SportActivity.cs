using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;
using System.Collections.Generic;
using SportAct.Reservations;
using SportAct.Locations;
using SportAct.ActivityTypes;

namespace SportAct.SportActivities

{
    public class SportActivity : AuditedAggregateRoot<Guid>
    {

        public string ActivityName { get; set; }
        public int Capacity { get; set; }
        public int Cost { get; set; }
        public int MinimumAge { get; set; }

        public int MaximumAge { get; set; }

        public DateTime StartedTime { get; set; }

        public DateTime EndedTime { get; set; }
        public string Description { get; set; }
        public virtual Location Location { get; set; }
        public Guid LocationId { get; set; }
        public virtual ActivityType ActivityType { get; set; } 
        public Guid ActivityTypeId { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
        private SportActivity()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal SportActivity(
            Guid id,
            [NotNull] string activityname,
            [NotNull] int capacity,
            [NotNull] int cost,
            [NotNull] int minimumage,
            [NotNull] int maximumage,
            [NotNull] DateTime startedtime,
            [NotNull] DateTime endedtime,
            [NotNull] string description



            )

            : base(id)
        {
            SetName(activityname);
            Capacity = capacity;
            Cost = cost;
            MinimumAge = minimumage;
            MaximumAge = maximumage;
            StartedTime = startedtime;
            EndedTime = endedtime;
            Description = description;



                
        }

        internal SportActivity ChangeName([NotNull] string activityname)
        {
            SetName(activityname);
            

            return this;
        }

        private void SetName([NotNull] string activityname)
        {
            ActivityName = Check.NotNullOrWhiteSpace(
                activityname,
                nameof(activityname),
                maxLength: SportActivityConsts.MaxActivityNameLength
            );
        }

    }
}
