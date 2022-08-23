namespace CurrencyyConverter.Infrastructure.Interfaces;

public interface ICurrencyService
{
    Task<double> Convert(string baseCurrency, string toCurrency, double amount);
}