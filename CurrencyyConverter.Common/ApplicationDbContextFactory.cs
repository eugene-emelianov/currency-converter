using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyyConverter.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CurrencyConverter.Infrastructure
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<CurrencyServiceDbContext>
    {
        public CurrencyServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration
                .GetConnectionString("CurrencyConverterService");

            optionsBuilder.UseSqlServer(connectionString);

            return new CurrencyServiceDbContext(optionsBuilder.Options);
        }
    }
}
