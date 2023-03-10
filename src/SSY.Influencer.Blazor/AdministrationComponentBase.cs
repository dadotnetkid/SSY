using Volo.Abp.AspNetCore.Components;

namespace SSY.Influencer.Blazor;

public abstract class AdministrationComponentBase : AbpComponentBase
{
    protected AdministrationComponentBase()
    {
        LocalizationResource = typeof(SSYResource);
    }
}
