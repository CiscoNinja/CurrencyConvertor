using Volo.Abp.Settings;

namespace CurrencyConvertor.Settings;

public class CurrencyConvertorSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CurrencyConvertorSettings.MySetting1));
    }
}
