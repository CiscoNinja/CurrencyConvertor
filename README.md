This project utilises the CurrencyServer from http://fx.currencysystem.com/ 

CurrencyConvertor How to run

1. Clone and open in VS
2. edit the connection string with your db user id and password

"ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=CurrencyConvertor;User ID=postgres;Password=yourpassword;"
  },
3. run the db migrator to create and seed database.
4. set CurrencyConvertor.HttpApi.Host as the startup project and run the app

test the currency APIs using the swagger interface. 
enter any of the currency pairs below to test

Available Currencies

AED;AFN;ALL;AOA;ARS;AUD;AZN;BBD;BDT;BGN;BHD;BND;BOB;BRL;BSD;BWP;BYN;BZD;CAD;CDF;CHF;CLP;CNY;
COP;CRC;CVE;CZK;DKK;DOP;DZD;EGP;ERN;ETB;EUR;FJD;GBP;GHS;GTQ;GYD;HKD;HNL;HRK;HTG;HUF;IDR;ILS;
INR;IQD;ISK;JMD;JOD;JPY;KES;KHR;KMF;KRW;KWD;KZT;LBP;LKR;LYD;MAD;MDL;MKD;MMK;MOP;MRU;MUR;MXN;
MYR;MZN;NAD;NGN;NIO;NOK;NPR;NZD;OMR;PAB;PEN;PGK;PHP;PKR;PLN;PYG;QAR;RON;RSD;RUB;SAR;SEK;SGD;
SRD;THB;TMT;TND;TRY;TTD;TWD;TZS;UAH;UGX;USD;UYU;UZS;VND;XAF;XCD;XDR;XOF;XPF;YER;ZAR;ZMW
