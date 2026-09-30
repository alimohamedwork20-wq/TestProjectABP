using TestProjectABP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TestProjectABP.Permissions;

public class TestProjectABPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TestProjectABPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(TestProjectABPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TestProjectABPResource>(name);
    }
}
