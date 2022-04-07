using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CurrencyConvertor.Data;
using Volo.Abp.DependencyInjection;

namespace CurrencyConvertor.EntityFrameworkCore;

public class EntityFrameworkCoreCurrencyConvertorDbSchemaMigrator
    : ICurrencyConvertorDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCurrencyConvertorDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CurrencyConvertorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CurrencyConvertorDbContext>()
            .Database
            .MigrateAsync();
    }
}
