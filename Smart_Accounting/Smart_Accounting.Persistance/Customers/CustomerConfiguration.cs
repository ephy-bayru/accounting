using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Persistance.Customers {
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure (EntityTypeBuilder<Customer> builder) {
            builder.ToTable ("CUSTOMER");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_CUSTOMER_account_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

            builder.Property (e => e.DateCreated)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime");

            builder.Property (e => e.FullName)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Customer)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_CUSTOMER_account");
        }
    }
}