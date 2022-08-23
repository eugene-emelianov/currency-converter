using CurrencyyConverter.Infrastructure.Interfaces;

namespace CurrencyyConverter.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IFxRatesServiceClient _fxRatesServiceClient;

        public CurrencyService(IFxRatesServiceClient fxRatesServiceClient)
        {
            _fxRatesServiceClient = fxRatesServiceClient;
        }

        public async Task<double> Convert(string baseCurrency, string toCurrency, double amount)
        {
            try
            {
                var fxRate = await _fxRatesServiceClient.GetLatestRateAsync(baseCurrency, toCurrency);

                if (fxRate == 0)
                    throw new ArgumentException($"Could not get latest currency rate for the pair : {baseCurrency}_{toCurrency}");

                return amount * fxRate;
            }
            catch (Exception ex)
            {
                //TODO log error
                throw;
            }
        }

        public async Task<double> Convert(string baseCurrency, string toCurrency, double amount, DateTime date)
        {
            try
            {
                var fxRate = await _fxRatesServiceClient.GetHistoricalRateAsync(baseCurrency, toCurrency, date);

                if (fxRate == 0)
                    throw new ArgumentException($"Could not get historical currency rate for the pair : {baseCurrency}_{toCurrency} on {date.Date}");

                return amount * fxRate;
            }
            catch (Exception ex)
            {
                //TODO log error
                throw;
            }
        }
    }
}