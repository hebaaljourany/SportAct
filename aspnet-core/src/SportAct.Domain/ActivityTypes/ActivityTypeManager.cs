using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SportAct.ActivityTypes
{
    public class ActivityTypeManager : DomainService
    {
        private readonly IActivityTypeRepository _activitytypeRepository;

        public ActivityTypeManager(IActivityTypeRepository activitytypeRepository)
        {
            _activitytypeRepository = activitytypeRepository;
        }

        public async Task<ActivityType> CreateAsync(
            [NotNull] string activitytypename
           )
        {
            Check.NotNullOrWhiteSpace(activitytypename, nameof(activitytypename));

            var existingActivityType = await _activitytypeRepository.FindByActivityTypeNameAsync(activitytypename);
            if (existingActivityType != null)
            {
                throw new ActivityTypeAlreadyExistsException(activitytypename);
            }

            return new ActivityType(
                GuidGenerator.Create(),
                activitytypename
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] ActivityType activitytype,
            [NotNull] string newName)
        {
            Check.NotNull(activitytype, nameof(activitytype));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingActivityType = await _activitytypeRepository.FindByActivityTypeNameAsync(newName);
            if (existingActivityType != null && existingActivityType.Id != activitytype.Id)
            {
                throw new ActivityTypeAlreadyExistsException(newName);
            }

            activitytype.ChangeName(newName);
        }
    }
}
