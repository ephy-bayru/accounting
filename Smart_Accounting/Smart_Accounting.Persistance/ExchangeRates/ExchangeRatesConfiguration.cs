using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Persistance.ExchangeRates {
    public class ExchangeRatesConfiguration : IEntityTypeConfiguration<ExchangeRate> {
        public void Configure (EntityTypeBuilder<ExchangeRate> builder) {
            builder.HasKey (e => e.Id);

            builder.ToTable ("exchange_rate");

            builder.Property (e => e.Id).HasColumnName ("RATE_ID");

            builder.Property (e => e.BuyRate).HasColumnName ("buy_rate");

            builder.Property (e => e.CurrencyCode)
                .IsRequired ()
                .HasColumnName ("CURRENCY_CODE")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Date)
                .HasColumnName ("date")
                .HasColumnType ("datetime");

            builder.Property (e => e.SaleRate).HasColumnName ("sale_rate");
        }
    }
}