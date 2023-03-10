using Volo.Abp.AspNetCore.Components;

namespace SSY.Blazor;

public abstract class SSYComponentBase : AbpComponentBase
{
    protected SSYComponentBase()
    {
        LocalizationResource = typeof(SSYResource);
    }
}
