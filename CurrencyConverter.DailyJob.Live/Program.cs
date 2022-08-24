using System;
using System.Threading.Tasks;
using CurrencyConverter.Infrastructure;
using CurrencyConverter.Infrastructure.Repositories;
using CurrencyyConverter.Infrastructure.Interfaces;
using CurrencyyConverter.Infrastructure.Services;

namespace CurrencyConverter.DailyJob.Live
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var currencyService = InitCurrencyService();

            try
            {
                Console.WriteLine("Enter base currency: ");
                var baseCurrency = Console.ReadLine();

                Console.WriteLine("Enter quote currency: ");
                var currencyTo = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(baseCurrency) || string.IsNullOrWhiteSpace(currencyTo))
                    throw new ArgumentException("Base or quote currencies can not be empty or whitespace.");

                var res = await currencyService.SyncUpFxRate(baseCurrency, currencyTo);

                Console.WriteLine($"Currency rates sync up {(res ? "completed" : "failed")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong! Error: {ex.Message}");
            }
        }

        private static ICurrencyService InitCurrencyService()
        {
            return new CurrencyService(
                new FixerApiService(),
                new FxRatesRepository(new ApplicationDbContextFactory().CreateDbContext(null)));
        }
    }
}
