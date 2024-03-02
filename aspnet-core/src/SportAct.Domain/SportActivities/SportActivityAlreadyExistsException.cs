using Volo.Abp;

namespace SportAct.SportActivities
{
    public class SportActivityAlreadyExistsException : BusinessException
    {
        public SportActivityAlreadyExistsException(string activityname)
            : base(SportActDomainErrorCodes.SportActivityAlreadyExists)
        {
            WithData("activityname", activityname);
        }
    }
}