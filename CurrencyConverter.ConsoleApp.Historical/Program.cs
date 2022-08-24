using System;
using System.Threading.Tasks;
using CurrencyyConverter.Infrastructure.Interfaces;
using CurrencyyConverter.Infrastructure.Services;

namespace CurrencyConverter.ConsoleApp.Historical
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var currencyService = InitCurrencyService();

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter currency to convert from: ");
                    var currencyFrom = Console.ReadLine();

                    Console.WriteLine("Enter currency to convert to: ");
                    var currencyTo = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(currencyFrom) || string.IsNullOrWhiteSpace(currencyTo))
                        throw new ArgumentException("Currency to convert from or to can not be empty or whitespace.");

                    Console.WriteLine("Enter amount: ");
                    var amountStr = Console.ReadLine();

                    if (!double.TryParse(amountStr, out var amount) || amount <= 0)
                        throw new ArgumentException("Amount must be a valid positive number.");

                    Console.WriteLine("Enter date: yyyy-mm-dd");
                    var dateStr = Console.ReadLine();

                    if (!DateTime.TryParse(dateStr, out var date) || date.Date >= DateTime.Now.Date)
                        throw new ArgumentException("Could not recognize past date. A date must be in the past for which historical rates are requested.");

                    var convertTask = currencyService.Convert(currencyFrom.Trim(), currencyTo.Trim(), amount, date);

                    Console.WriteLine("Please wait...");

                    var res = await convertTask;

                    Console.WriteLine($"Result: On {date:yyyy-MM-dd} {amount} {currencyFrom} = {res} {currencyTo} {Environment.NewLine}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong! Error: {ex.Message}");
                }
            }
        }

        private static ICurrencyService InitCurrencyService()
        {
            return new CurrencyService(new FixerApiService(), null);
        }
    }
}
