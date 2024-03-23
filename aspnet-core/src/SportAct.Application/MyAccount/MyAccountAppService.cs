using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using SportAct.Domain;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Account.Emailing;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using Volo.Abp.Account.Localization;
using Volo.Abp.Application.Services;

namespace SportAct.MyAccount
{
    public class MyAccountAppService : AccountAppService, IAccountAppService, ITransientDependency
    {
        private readonly IClientRepository _clientRepository;

        public MyAccountAppService(
            IClientRepository clientRepository,
            IIdentityRoleRepository roleRepository,
            IdentityUserManager userManager,
            IAccountEmailer accountEmailer,
            IdentitySecurityLogManager identitySecurityLogManager,
            IOptions<IdentityOptions> identityOptions
            
            ) : base(userManager, roleRepository, accountEmailer, identitySecurityLogManager, identityOptions)
        {
            _clientRepository = clientRepository;
        }

        public async override Task<IdentityUserDto> RegisterAsync(RegisterDto input)
        {
            var userDto = await base.RegisterAsync(input);
            var user = await UserManager.FindByIdAsync(userDto.Id.ToString());
            await base.UserManager.AddToRoleAsync(user, "Client");
            // Your custom logic to add UserId to Client entity
            var client = new Client
            {
                UserId = userDto.Id,
                // Other properties initialization
            };
            await _clientRepository.InsertAsync(client);

            return userDto;
        }
    }
}
