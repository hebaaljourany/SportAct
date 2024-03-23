using SportAct.Domain;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;

namespace SportAct.Controllers
{
    [Dependency(ReplaceServices = true)]
    //[ExposeServices(typeof(AccountController))]
    [ExposeServices(typeof(AccountController)/*, IncludeSelf = true*/)]
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
        /* public MyAccountController(
             IAccountAppService accountAppService,
             IClientRepository clientRepository)
             : base(accountAppService)
         {
             _clientRepository = clientRepository;
         }
        // [HttpPost("my-register")]


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


             return userDto;
         }*/
        /*
        [HttpPost("my-send-password-reset-code")]
        public async override Task SendPasswordResetCodeAsync(
            SendPasswordResetCodeDto input)
        {
            Logger.LogInformation("Your custom logic...");

            await base.SendPasswordResetCodeAsync(input);
        }
        [HttpPost("my-reset-password")]
        public async override Task ResetPasswordAsync(
           ResetPasswordDto input)
        {
            Logger.LogInformation("Your custom logic...");

            await base.ResetPasswordAsync(input);
        }*/
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
