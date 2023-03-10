using SSY.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SSY;

[DependsOn(
    typeof(SSYEntityFrameworkCoreTestModule)
    )]
public class SSYDomainTestModule : AbpModule
{

}
