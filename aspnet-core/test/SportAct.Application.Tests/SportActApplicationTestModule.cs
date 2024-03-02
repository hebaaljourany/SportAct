using Volo.Abp.Modularity;

namespace SportAct;

[DependsOn(
    typeof(SportActApplicationModule),
    typeof(SportActDomainTestModule)
    )]
public class SportActApplicationTestModule : AbpModule
{

}
