namespace CurrencyyConverter.Infrastructure.Interfaces;

public interface ICurrencyService
{
    /// <summary>
    /// Returns latest FX rate for a currency pair
    /// </summary>
    /// <param name="baseCurrency"></param>
    /// <param name="toCurrency"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    Task<double> Convert(string baseCurrency, string toCurrency, double amount);

    /// <summary>
    /// Returns historical FX rate for a currency pair
    /// </summary>
    /// <param name="baseCurrency"></param>
    /// <param name="toCurrency"></param>
    /// <param name="amount"></param>
    /// <param name="date"></param>
    /// <returns></returns>
    Task<double> Convert(string baseCurrency, string toCurrency, double amount, DateTime date);

    /// <summary>
    /// Get and save latest rate for the currency pair
    /// </summary>
    /// <param name="baseCurrency"></param>
    /// <param name="currencyTo"></param>
    /// <returns></returns>
    Task<bool> SyncUpFxRate(string baseCurrency, string currencyTo);
}