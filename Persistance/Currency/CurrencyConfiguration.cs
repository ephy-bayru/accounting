namespace Smart_Accounting.Persistance.Currency
{
    public class CurrencyConfiguration: EntityTypeConfiguration<Currency> 
    {
        
        public CurrencyConfiguration() {
                ToTable("currency");

                HasIndex(e => e.Abrevation)
                    .HasName("abrevation_UNIQUE")
                    .IsUnique();

                HasIndex(e => e.Country)
                    .HasName("country_UNIQUE")
                    .IsUnique();

                HasIndex(e => e.ExchangeRateRateId)
                    .HasName("fk_currency_exchange_rate1_idx");

                HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                Property(e => e.CurrencyId).HasColumnName("CURRENCY_ID");

                Property(e => e.Abrevation)
                    .IsRequired()
                    .HasColumnName("abrevation")
                    .HasColumnType("varchar(45)");

                Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(45)");

                Property(e => e.ExchangeRateRateId).HasColumnName("exchange_rate_RATE_ID");

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                Property(e => e.Symbole)
                    .IsRequired()
                    .HasColumnName("symbole")
                    .HasColumnType("varchar(10)");

                HasOne(d => d.ExchangeRateRate)
                    .WithMany(p => p.Currency)
                    .HasForeignKey(d => d.ExchangeRateRateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_currency_exchange_rate1");
        }
    }
}