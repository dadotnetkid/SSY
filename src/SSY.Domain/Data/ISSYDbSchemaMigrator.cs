using System.Threading.Tasks;

namespace SSY.Data;

public interface ISSYDbSchemaMigrator
{
    Task MigrateAsync();
}
