using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SSY.Influencer.Blazor;

[Dependency(ReplaceServices = true)]
public class AdministrationBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Administration";
}
