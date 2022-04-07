using System;
using System.Collections.Generic;
using System.Text;
using CurrencyConvertor.Localization;
using Volo.Abp.Application.Services;

namespace CurrencyConvertor;

/* Inherit your application services from this class.
 */
public abstract class CurrencyConvertorAppService : ApplicationService
{
    protected CurrencyConvertorAppService()
    {
        LocalizationResource = typeof(CurrencyConvertorResource);
    }
}
