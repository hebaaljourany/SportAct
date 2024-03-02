using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SportAct.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace SportAct.MyIdentity
{
 public class MyIdentityAppService : IdentityUserAppService
{
    private readonly IClientRepository _clientRepository;

    public MyIdentityAppService(
        IClientRepository clientRepository,
        IdentityUserManager userManager,
        IIdentityUserRepository identityUserRepository,
        IIdentityRoleRepository identityRoleRepository,
        IOptions<IdentityOptions> identityOptions
    ) : base(userManager, identityUserRepository, identityRoleRepository, identityOptions)

        {
            _clientRepository = clientRepository;
        // ... initialize other dependencies  
    }
        // [Authorize("AbpIdentity.Users.Create")]
        //[Authorize(Roles = "Admin")]
        // [Authorize(Policy = "CreateUserPolicy")]
        [Authorize]
        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
    {
        var userDto = await base.CreateAsync(input);

        // Create a Client record
        var client = new Client
        {
            UserId = userDto.Id,
            // Other properties if any
        };

        await _clientRepository.InsertAsync(client);
        await CurrentUnitOfWork.SaveChangesAsync();

            return userDto;
    }
}

}
