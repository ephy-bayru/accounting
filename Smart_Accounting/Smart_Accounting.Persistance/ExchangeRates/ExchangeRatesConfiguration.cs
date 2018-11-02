/*
 * @CreateTime: Nov 2, 2018 3:27 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:27 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.ExchangeRates;

namespace Smart_Accounting.Persistance.ExchangeRates {
    public class ExchangeRatesConfiguration : IEntityTypeConfiguration<ExchangeRate> {
        public void Configure (EntityTypeBuilder<ExchangeRate> builder) {
            builder.ToTable ("exchange_rate");

            builder.HasIndex (e => e.Currency)
                .HasName ("fk_exrate_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BuyRate).HasColumnName ("buy_rate");

            builder.Property (e => e.Currency)
                .HasColumnName ("currency")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Date)
                .HasColumnName ("date")
                .HasColumnType ("datetime");

            builder.Property (e => e.DateCreated)
                .HasColumnName ("date_created")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.SaleRate).HasColumnName ("sale_rate");
        }
    }
}