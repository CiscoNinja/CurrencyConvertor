using CurrencyConvertor.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace CurrencyConvertor;

[DependsOn(
    typeof(CurrencyConvertorEntityFrameworkCoreTestModule)
    )]
public class CurrencyConvertorDomainTestModule : AbpModule
{

}
