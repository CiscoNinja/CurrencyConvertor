using CurrencyConvertor.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CurrencyConvertor.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CurrencyConvertorEntityFrameworkCoreModule),
    typeof(CurrencyConvertorApplicationContractsModule)
    )]
public class CurrencyConvertorDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
