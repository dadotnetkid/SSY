using SSY.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SSY.Permissions;

public class SSYPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SSYPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SSYPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SSYResource>(name);
    }
}
