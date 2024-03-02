using SportAct.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SportAct;

[DependsOn(
    typeof(SportActEntityFrameworkCoreTestModule)
    )]
public class SportActDomainTestModule : AbpModule
{

}
