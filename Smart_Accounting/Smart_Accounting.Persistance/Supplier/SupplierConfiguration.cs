using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Persistance.Supplier {
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers> {
        public void Configure (EntityTypeBuilder<Suppliers> builder) {

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Suppliers)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_suppliers_account");
        }
    }
}