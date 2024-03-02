using SportAct.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SportAct.Permissions;

public class SportActPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SportActPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SportActPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SportActResource>(name);
    }
}
