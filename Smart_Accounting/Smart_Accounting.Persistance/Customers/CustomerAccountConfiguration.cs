namespace Smart_Accounting.Persistance.Customers {
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure (EntityTypeBuilder<Customer> builder) {
            builder.ToTable ("customer_account");

            builder.HasIndex (e => e.CustomerId)
                .HasName ("fk_customer_account_idx");

            builder.Property (e => e.Id).HasColumnName ("id");

            builder.Property (e => e.AccountNumber)
                .IsRequired ()
                .HasColumnName ("Account_Number")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.BankName)
                .IsRequired ()
                .HasColumnName ("Bank_Name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.CustomerId).HasColumnName ("Customer_Id");

            builder.HasOne (d => d.Customer)
                .WithMany (p => p.CustomerAccount)
                .HasForeignKey (d => d.CustomerId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_customer_account");
        }
    }
}