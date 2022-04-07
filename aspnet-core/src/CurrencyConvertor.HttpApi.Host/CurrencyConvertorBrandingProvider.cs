using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace CurrencyConvertor;

[Dependency(ReplaceServices = true)]
public class CurrencyConvertorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CurrencyConvertor";
}
