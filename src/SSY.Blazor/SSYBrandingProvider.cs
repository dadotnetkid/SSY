using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SSY.Blazor;

[Dependency(ReplaceServices = true)]
public class SSYBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SSY";
}
