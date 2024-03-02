using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using SportAct.Domain;


namespace SportAct.Controllers
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(AccountController))]
    public class MyAccountController : AccountController
    {
        private readonly IClientRepository _clientRepository;
        public MyAccountController(
            IAccountAppService accountAppService,
            IClientRepository clientRepository)
            : base(accountAppService)
        {
            _clientRepository = clientRepository;
        }

        public async override Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            var userDto = await base.RegisterAsync(input);

            // Your custom logic to add UserId to Client entity
            var client = new Client
            {
                UserId = userDto.Id,
                // Other properties initialization
            };
            await _clientRepository.InsertAsync(client);

            Logger.LogInformation("Your custom logic...");

            return userDto;
        }
    }
}

/* Inherit your controllers from this class.
 */
/*public abstract class SportActController : AbpControllerBase
{
    protected SportActController()
    {
        LocalizationResource = typeof(SportActResource);
    }
}*/
