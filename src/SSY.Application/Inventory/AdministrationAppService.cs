namespace SSY.Inventory;

/* Inherit your application services from this class.
 */
public abstract class AdministrationAppService : ApplicationService
{
    protected AdministrationAppService()
    {
        LocalizationResource = typeof(SSYResource);
    }
}
