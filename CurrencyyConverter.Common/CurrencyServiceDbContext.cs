using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyyConverter.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CurrencyyConverter.Infrastructure
{
    public class CurrencyServiceDbContext : DbContext
    {
        public virtual DbSet<FxRate> FxRates { get; set; }

        public CurrencyServiceDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyServiceDbContext).Assembly);
        }
    }
}
