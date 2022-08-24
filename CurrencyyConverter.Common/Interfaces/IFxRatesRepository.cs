using CurrencyyConverter.Infrastructure.Models;

namespace CurrencyyConverter.Infrastructure.Interfaces;

public interface IFxRatesRepository
{
    Task AddFxRateAsync(FxRate fxRate);
    Task<int> SaveChangesAsync();
}