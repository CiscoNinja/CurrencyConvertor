using CurrencyConvertor.Currencies;
using CurrencyConvertor.Currencies.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace CurrencyConvertor.AppServices
{
    public class CurrencyAppService :
    CrudAppService<
            Currency,
            CurrencyDto,
            int,
            PagedAndSortedResultRequestDto,
            CreateUpdateCurrencyDto, 
            CurrencyDto>, ICurrencyAppService
    {
        public CurrencyAppService(IRepository<Currency, int> repository)
            : base(repository)
        {

        }
        public async Task<Decimal> Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            var result = ConvertCurrency(amount, fromCurrency, toCurrency);
            return result;
        }
        public static string CurrencyConvert(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal currency = 0;
            string convertedAmount = "0";
            try
            {
                string url = string.Format("https://www.google.com/finance/converter?a={2}&from={0}&to={1}", fromCurrency.ToUpper(), toCurrency.ToUpper(), amount);
                WebRequest request = WebRequest.Create(url);
                StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);
                string result = Regex.Matches(streamReader.ReadToEnd(), "([^<]+)")[0].Groups[1].Value;
                string rs = new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*").Match(result).Groups[1].Value;
                if (decimal.TryParse((new Regex(@"^\D*?((-?(\d+(\.\d+)?))|(-?\.\d+)).*").Match(result).Groups[1].Value), out currency))
                {
                    convertedAmount = currency.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return convertedAmount;
        }

        //[WebMethod]
        public static decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            WebClient client = new WebClient();
            Stream response = client.OpenRead(string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCurrency.ToUpper(), toCurrency.ToUpper()));
            StreamReader reader = new StreamReader(response);
            string yahooResponse = reader.ReadLine();
            response.Close();
            if (!string.IsNullOrWhiteSpace(yahooResponse))
            {
                string[] values = Regex.Split(yahooResponse, ",");
                if (values.Length > 0)
                {
                    decimal rate = System.Convert.ToDecimal(values[1]);
                    return rate * amount;
                }
            }
            return 0;
        }
    }
}
