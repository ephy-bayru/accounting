using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Persistance.Supplier {
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers> {
        public void Configure (EntityTypeBuilder<Suppliers> builder) {
            builder.HasKey (e => e.SupplierId);

            builder.ToTable ("suppliers");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_suppliers_account_idx");

            builder.Property (e => e.SupplierId)
                .HasColumnName ("SUPPLIER_ID")
                .HasColumnType ("int(11)");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)");

            builder.Property (e => e.BankAccount)
                .HasColumnName ("bank_account")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.CreditLimit)
                .HasColumnName ("credit_limit")
                .HasColumnType ("int(11)");

            builder.Property (e => e.Discription)
                .HasColumnName ("discription")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.TaxIncluded)
                .HasColumnName ("tax_included")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Suppliers)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_suppliers_account");
        }
    }
}