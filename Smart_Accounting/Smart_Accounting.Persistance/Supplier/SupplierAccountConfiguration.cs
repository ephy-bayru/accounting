namespace Smart_Accounting.Persistance.Supplier {
    public class SupplierAccountConfiguration : IEntityTypeConfiguration<Suppliers> {
        public void Configure (EntityTypeBuilder<Suppliers> builder) {
            builder.ToTable ("supplier_account");

            builder.HasIndex (e => e.SupplierId)
                .HasName ("fk_supplier_account_idx");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.AccountNumber)
                .IsRequired ()
                .HasColumnName ("Account_Number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.BankName)
                .IsRequired ()
                .HasColumnName ("Bank_Name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.SupplierId).HasColumnName ("Supplier_Id");

            builder.HasOne (d => d.Supplier)
                .WithMany (p => p.SupplierAccount)
                .HasForeignKey (d => d.SupplierId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_supplier_account");
        }
    }
}