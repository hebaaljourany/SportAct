using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SportAct.SportActivities
{
    public class SportActivityManager : DomainService
    {
        private readonly ISportActivityRepository _sportactivityRepository;

        public SportActivityManager(ISportActivityRepository sportactivityRepository)
        {
            _sportactivityRepository = sportactivityRepository;
        }

        public async Task<SportActivity> CreateAsync(
            [NotNull] string activityname,
            [NotNull] int capacity,
            [NotNull] int cost,
            [NotNull] int minimumage,
            [NotNull] int maximumage,
            [NotNull] DateTime startedtime,
            [NotNull] DateTime endedtime,
            [NotNull] string description
           )
        {
            Check.NotNullOrWhiteSpace(activityname, nameof(activityname));

            var existingSportActivity = await _sportactivityRepository.FindByActivityNameAsync(activityname);
            if (existingSportActivity != null)
            {
                throw new SportActivityAlreadyExistsException(activityname);
            }

            return new SportActivity(
                GuidGenerator.Create(),
                activityname,
                capacity,
                cost,
                minimumage,
                maximumage,
                startedtime,
                endedtime,
                description

            );
        }

        public async Task ChangeNameAsync(
            [NotNull] SportActivity sportactivity,
            [NotNull] string newName)
        {
            Check.NotNull(sportactivity, nameof(sportactivity));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingSportActivity = await _sportactivityRepository.FindByActivityNameAsync(newName);
            if (existingSportActivity != null && existingSportActivity.Id != sportactivity.Id)
            {
                throw new SportActivityAlreadyExistsException(newName);
            }

            sportactivity.ChangeName(newName);
        }
    }
}
