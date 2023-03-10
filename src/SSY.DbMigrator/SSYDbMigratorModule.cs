using SSY.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SSY.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SSYEntityFrameworkCoreModule),
    typeof(SSYApplicationContractsModule),
    typeof(SSYApplicationModule)
    )]
public class SSYDbMigratorModule : AbpModule
{

}
