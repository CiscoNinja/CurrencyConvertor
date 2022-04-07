using CurrencyConvertor.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CurrencyConvertor.Permissions;

public class CurrencyConvertorPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CurrencyConvertorPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CurrencyConvertorPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CurrencyConvertorResource>(name);
    }
}
