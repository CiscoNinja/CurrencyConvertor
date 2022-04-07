using CurrencyConvertor.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace CurrencyConvertor.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CurrencyConvertorController : AbpControllerBase
{
    protected CurrencyConvertorController()
    {
        LocalizationResource = typeof(CurrencyConvertorResource);
    }
}
