using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SportAct.Data;

/* This is used if database provider does't define
 * ISportActDbSchemaMigrator implementation.
 */
public class NullSportActDbSchemaMigrator : ISportActDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
