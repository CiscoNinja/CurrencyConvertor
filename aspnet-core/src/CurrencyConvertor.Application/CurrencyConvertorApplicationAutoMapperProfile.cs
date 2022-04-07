using AutoMapper;
using CurrencyConvertor.Currencies.Dto;
using CurrencyConvertor.Currencies;

namespace CurrencyConvertor;

public class CurrencyConvertorApplicationAutoMapperProfile : Profile
{
    public CurrencyConvertorApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Currency, CurrencyDto>();
        CreateMap<CreateUpdateCurrencyDto, Currency>();
    }
}
