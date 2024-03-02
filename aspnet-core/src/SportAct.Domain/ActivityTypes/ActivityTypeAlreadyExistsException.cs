using Volo.Abp;

namespace SportAct.ActivityTypes
{
    public class ActivityTypeAlreadyExistsException : BusinessException
    {
        public ActivityTypeAlreadyExistsException(string activitytype)
            : base(SportActDomainErrorCodes.ActivityTypeAlreadyExists)
        {
            WithData("activitytypename", activitytype);
        }
    }
}