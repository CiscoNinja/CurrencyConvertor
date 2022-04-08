CurrencyConvertor How to run

1. Clone and open in VS
2. edit the connection string with your db user id and password
"ConnectionStrings": {
    "Default": "Host=localhost;Port=5432;Database=CurrencyConvertor;User ID=postgres;Password=yourpassword;"
  },
3. run the db migrator to create and seed database.
4. set CurrencyConvertor.HttpApi.Host as the startup project and run the app

test the currency APIs using the swagger interface. 
