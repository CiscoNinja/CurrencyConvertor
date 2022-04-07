using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CurrencyConvertor.Currencies.Dto
{
    public class CreateUpdateCurrencyDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
