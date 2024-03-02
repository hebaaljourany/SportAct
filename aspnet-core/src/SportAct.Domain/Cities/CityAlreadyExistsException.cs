using Volo.Abp;

namespace SportAct.Cities
{
    public class CityAlreadyExistsException : BusinessException
    {
        public CityAlreadyExistsException(string cityname)
            : base(SportActDomainErrorCodes.CityAlreadyExists)
        {
            WithData("cityname", cityname);
        }
    }
}