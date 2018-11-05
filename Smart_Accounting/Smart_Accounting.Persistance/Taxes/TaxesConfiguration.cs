/*
 * @CreateTime: Nov 2, 2018 3:35 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:41 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Taxes;

namespace Smart_Accounting.Persistance.Taxes {
    public class TaxesConfiguration : IEntityTypeConfiguration<Tax> {
        public void Configure (EntityTypeBuilder<Tax> builder) {
            builder.ToTable ("tax");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_tax_account_idx");

            builder.Property (e => e.TaxType)
                .HasColumnName ("tax_type")
                .HasColumnType ("varchar(20)");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AccountId)
                .IsRequired ()
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.Amount).HasColumnName ("amount");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.IncludeInPrice)
                .HasColumnName ("include_in_price")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

        }
    }
}