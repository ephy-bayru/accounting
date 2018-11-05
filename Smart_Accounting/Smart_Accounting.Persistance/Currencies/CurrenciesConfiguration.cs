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

            builder.HasIndex (e => e.Name)
                .HasName ("name_UNIQUE")
                .IsUnique ();

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Abrevation)
                .IsRequired ()
                .HasColumnName ("abrevation")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .IsRequired ()
                .HasColumnName ("country")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Symbole)
                .IsRequired ()
                .HasColumnName ("symbole")
                .HasColumnType ("varchar(10)");
        }
    }
}