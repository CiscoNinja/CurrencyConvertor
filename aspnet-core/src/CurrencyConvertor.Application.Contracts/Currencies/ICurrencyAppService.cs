using CurrencyConvertor.Currencies.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CurrencyConvertor.Currencies
{
    public interface ICurrencyAppService : ICrudAppService<
            CurrencyDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateCurrencyDto,
            CurrencyDto>
    {
        Task<decimal> Convert(decimal amount, string fromCurrency, string toCurrency);
    }
}
