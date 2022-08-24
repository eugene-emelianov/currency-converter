using CurrencyyConverter.Infrastructure.Interfaces;
using CurrencyyConverter.Infrastructure.Models;

namespace CurrencyyConverter.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IFxRatesServiceClient _fxRatesServiceClient;
        private readonly IFxRatesRepository _fxRatesRepository;

        public CurrencyService(IFxRatesServiceClient fxRatesServiceClient, IFxRatesRepository fxRatesRepository)
        {
            _fxRatesServiceClient = fxRatesServiceClient;
            _fxRatesRepository = fxRatesRepository;
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

        public async Task<bool> SyncUpFxRate(string baseCurrency, string currencyTo)
        {
            try
            {
                var rate = await _fxRatesServiceClient.GetLatestRateAsync(baseCurrency, currencyTo);

                if (rate == 0)
                    return false;

                var fxRate = new FxRate
                {
                    BaseCurrency = baseCurrency,
                    QuoteCurrency = currencyTo,
                    Rate = rate,
                    Date = DateTime.Now.Date
                };

                await _fxRatesRepository.AddFxRateAsync(fxRate);
                await _fxRatesRepository.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                //TODO log error
                return false;
            }
        }
    }
}