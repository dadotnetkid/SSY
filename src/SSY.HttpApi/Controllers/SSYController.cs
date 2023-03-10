using SSY.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SSY.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SSYController : AbpControllerBase
{
    protected SSYController()
    {
        LocalizationResource = typeof(SSYResource);
    }
}
