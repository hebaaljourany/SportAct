using SportAct.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace SportAct.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SportActEntityFrameworkCoreModule),
    typeof(SportActApplicationContractsModule)
    )]
public class SportActDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
