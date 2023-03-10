using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SSY.Data;

/* This is used if database provider does't define
 * ISSYDbSchemaMigrator implementation.
 */
public class NullSSYDbSchemaMigrator : ISSYDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
