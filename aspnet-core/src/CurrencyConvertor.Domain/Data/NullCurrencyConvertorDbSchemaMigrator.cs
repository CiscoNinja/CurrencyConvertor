using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CurrencyConvertor.Data;

/* This is used if database provider does't define
 * ICurrencyConvertorDbSchemaMigrator implementation.
 */
public class NullCurrencyConvertorDbSchemaMigrator : ICurrencyConvertorDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
