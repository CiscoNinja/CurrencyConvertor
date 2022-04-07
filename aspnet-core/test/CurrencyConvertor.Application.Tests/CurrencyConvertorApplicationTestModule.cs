using Volo.Abp.Modularity;

namespace CurrencyConvertor;

[DependsOn(
    typeof(CurrencyConvertorApplicationModule),
    typeof(CurrencyConvertorDomainTestModule)
    )]
public class CurrencyConvertorApplicationTestModule : AbpModule
{

}
