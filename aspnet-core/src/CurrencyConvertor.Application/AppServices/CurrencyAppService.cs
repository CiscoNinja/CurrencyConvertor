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
using System.Xml;
using System.Xml.Linq;
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
        public async Task<string> Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            var result = ConvertCurrency(amount, fromCurrency, toCurrency);
            return result;
        }

        public async Task<List<string>> GetCurrencies()
        {
            var result = GetAvailbleCurrencies();
            return result;
        }

        public static string ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal currency = 0;
            string convertedAmount = "0";
            try
            {
                string url = string.Format("http://fx.currencysystem.com/webservices/CurrencyServer4.asmx/ConvertToNum?licenseKey=&fromCurrency="+ fromCurrency.ToUpper() + "&toCurrency="+ toCurrency.ToUpper() + "&amount="+ amount +"&rounding=true&date=&type=");
                WebRequest request = WebRequest.Create(url);
                StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                currency =  decimal.Parse(doc.InnerText);
                
                convertedAmount = currency.ToString("0.00");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return convertedAmount;
        }

        public static List<string> GetAvailbleCurrencies()
        {
            var currencies = new List<string>();
            try
            {
                string url = string.Format("http://fx.currencysystem.com//webservices/CurrencyServer4.asmx/Currencies?licenseKey=");
                WebRequest request = WebRequest.Create(url);
                StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);

                currencies = doc.InnerText.Split(";").ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return currencies;
        }


        ////[WebMethod]
        //public static decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        //{
        //    WebClient client = new WebClient();
        //    Stream response = client.OpenRead(string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCurrency.ToUpper(), toCurrency.ToUpper()));
        //    StreamReader reader = new StreamReader(response);
        //    string yahooResponse = reader.ReadLine();
        //    response.Close();
        //    if (!string.IsNullOrWhiteSpace(yahooResponse))
        //    {
        //        string[] values = Regex.Split(yahooResponse, ",");
        //        if (values.Length > 0)
        //        {
        //            decimal rate = System.Convert.ToDecimal(values[1]);
        //            return rate * amount;
        //        }
        //    }
        //    return 0;
        //}

        ////Stream response = client.OpenRead(string.Format("http://fx.currencysystem.com/webservices/CurrencyServer4.asmx/ConvertToNum?licenseKey=&fromCurrency=USD&toCurrency=GHS&amount=1&rounding=true&date=&type="));
        //public static decimal ConvertAmount(decimal amount, string fromCurrency, string toCurrency)
        //{
        //    WebClient client = new WebClient();
        //    Stream response = client.OpenRead(string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCurrency.ToUpper(), toCurrency.ToUpper()));
        //    StreamReader reader = new StreamReader(response);
        //    string yahooResponse = reader.ReadLine();
        //    response.Close();
        //    if (!string.IsNullOrWhiteSpace(yahooResponse))
        //    {
        //        string[] values = Regex.Split(yahooResponse, ",");
        //        if (values.Length > 0)
        //        {
        //            decimal rate = System.Convert.ToDecimal(values[1]);
        //            return rate * amount;
        //        }
        //    }
        //    return 0;
        //}
    }
}
