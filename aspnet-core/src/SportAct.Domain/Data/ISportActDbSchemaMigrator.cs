using System.Threading.Tasks;

namespace SportAct.Data;

public interface ISportActDbSchemaMigrator
{
    Task MigrateAsync();
}
