namespace Smart_Accounting.Persistance.Suppliers
{
    public class SuppliersConfiguration: EntityTypeConfiguration<Suppliers>
    {
        public SuppliersConfiguration() {
            HasKey(e => e.SupplierId);

                ToTable("suppliers");

                HasIndex(e => e.AccountId)
                    .HasName("fk_suppliers_account_idx");

                Property(e => e.SupplierId)
                    .HasColumnName("SUPPLIER_ID")
                    .HasColumnType("int(11)");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                Property(e => e.BankAccount)
                    .HasColumnName("bank_account")
                    .HasColumnType("varchar(45)");

                Property(e => e.CreditLimit)
                    .HasColumnName("credit_limit")
                    .HasColumnType("int(11)");

                Property(e => e.Discription)
                    .HasColumnName("discription")
                    .HasColumnType("varchar(45)");

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                Property(e => e.TaxIncluded)
                    .HasColumnName("tax_included")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                HasOne(d => d.Account)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_suppliers_account");
        }
        
    }
}