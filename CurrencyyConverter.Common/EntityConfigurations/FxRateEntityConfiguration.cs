using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurrencyyConverter.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyConverter.Infrastructure.EntityConfigurations
{
    public class FxRateEntityConfiguration : IEntityTypeConfiguration<FxRate>
    {
        public void Configure(EntityTypeBuilder<FxRate> builder)
        {
            builder.HasKey(u => u.FxRateId);

            builder.Property(u => u.FxRateId)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.BaseCurrency)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(u => u.QuoteCurrency)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(u => u.Rate)
                .IsRequired();

            builder.Property(u => u.Date)
                .IsRequired();
        }
    }
}
