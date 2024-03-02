using Volo.Abp;

namespace SportAct.Locations
{
    public class LocationAlreadyExistsException : BusinessException
    {
        public LocationAlreadyExistsException(string locationname)
            : base(SportActDomainErrorCodes.LocationAlreadyExists)
        {
            WithData("locationname", locationname);
        }
    }
}