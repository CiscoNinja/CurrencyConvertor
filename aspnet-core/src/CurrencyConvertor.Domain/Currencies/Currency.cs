using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace CurrencyConvertor.Currencies
{
    public class Currency : Entity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
    }
}
