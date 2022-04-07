using System.Threading.Tasks;

namespace CurrencyConvertor.Data;

public interface ICurrencyConvertorDbSchemaMigrator
{
    Task MigrateAsync();
}
