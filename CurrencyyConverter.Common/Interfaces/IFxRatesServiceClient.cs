namespace CurrencyyConverter.Infrastructure.Interfaces;

public interface IFxRatesServiceClient
{
    Task<double> GetLatestRateAsync(string baseCurrency, string toCurrency);
}