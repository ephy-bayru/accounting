using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Currencies;

namespace Smart_Accounting.Persistance.Currencys {
    public class CurrenciesConfiguration : IEntityTypeConfiguration<Currency> {

        public void Configure (EntityTypeBuilder<Currency> builder) {
            builder.ToTable ("currency");

            builder.HasIndex (e => e.Abrevation)
                .HasName ("abrevation_UNIQUE")
                .IsUnique ();

            builder.HasIndex (e => e.Country)
                .HasName ("country_UNIQUE")
                .IsUnique ();

            builder.HasIndex (e => e.ExchangeRateRateId)
                .HasName ("fk_currency_exchange_rate1_idx");

            builder.HasIndex (e => e.Name)
                .HasName ("name_UNIQUE")
                .IsUnique ();

            builder.Property (e => e.CurrencyId).HasColumnName ("CURRENCY_ID");

            builder.Property (e => e.Abrevation)
                .IsRequired ()
                .HasColumnName ("abrevation")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .IsRequired ()
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.ExchangeRateRateId).HasColumnName ("exchange_rate_RATE_ID");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Symbole)
                .IsRequired ()
                .HasColumnName ("symbole")
                .HasColumnType ("varchar(10)");

            builder.HasOne (d => d.ExchangeRateRate)
                .WithMany (p => p.Currency)
                .HasForeignKey (d => d.ExchangeRateRateId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_currency_exchange_rate1");
        }
    }
}