using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Taxes;

namespace Smart_Accounting.Persistance.Taxes {
    public class TaxesConfiguration : IEntityTypeConfiguration<Tax> {
        public void Configure (EntityTypeBuilder<Tax> builder) {
            builder.ToTable ("TAX");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_table1_account_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

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

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Tax)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_table1_account");
        }
    }
}