using Volo.Abp.Modularity;

namespace SSY;

[DependsOn(
    typeof(SSYApplicationModule),
    typeof(SSYDomainTestModule)
    )]
public class SSYApplicationTestModule : AbpModule
{

}
