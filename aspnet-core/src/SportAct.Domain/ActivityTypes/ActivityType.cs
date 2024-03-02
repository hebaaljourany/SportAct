using System;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;

namespace SportAct.ActivityTypes

{
    public class ActivityType : AuditedAggregateRoot<Guid>
    {


        public string ActivityTypeName { get; set; }

        //////////
        private ActivityType()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal ActivityType(
            Guid id,
            [NotNull] string activitytypename)
            : base(id)
        {
            SetName(activitytypename);

        }

        internal ActivityType ChangeName([NotNull] string activitytypename)
        {
            SetName(activitytypename);
            return this;
        }

        private void SetName([NotNull] string activitytypename)
        {
            ActivityTypeName = Check.NotNullOrWhiteSpace(
                activitytypename,
                nameof(activitytypename),
                maxLength: ActivityTypeConsts.MaxActivityTypeNameLength
            );
        }


    }
}
