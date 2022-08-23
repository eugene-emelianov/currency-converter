namespace CurrencyyConverter.Infrastructure.Interfaces;

public interface IFxRatesServiceClient
{
    Task<double> GetLatestRateAsync(string baseCurrency, string toCurrency);
    Task<double> GetHistoricalRateAsync(string baseCurrency, string toCurrency, DateTime date);
}