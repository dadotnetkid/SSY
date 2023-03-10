using System;
using System.Collections.Generic;
using System.Text;

namespace SSY;

/* Inherit your application services from this class.
 */
public abstract class SSYAppService : ApplicationService
{
    protected SSYAppService()
    {
        LocalizationResource = typeof(SSYResource);
    }
}
