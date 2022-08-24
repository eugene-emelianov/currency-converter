using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyyConverter.Infrastructure;
using CurrencyyConverter.Infrastructure.Interfaces;
using CurrencyyConverter.Infrastructure.Models;

namespace CurrencyConverter.Infrastructure.Repositories
{
    public class FxRatesRepository : IFxRatesRepository
    {
        private readonly CurrencyServiceDbContext _context;

        public FxRatesRepository(CurrencyServiceDbContext context)
        {
            _context = context;
        }

        public async Task AddFxRateAsync(FxRate fxRate)
        {
            await _context.FxRates.AddAsync(fxRate);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
