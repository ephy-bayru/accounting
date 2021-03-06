/*
 * @CreateTime: Nov 2, 2018 3:26 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:26 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Persistance.Customers {
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount> {
        public void Configure (EntityTypeBuilder<CustomerAccount> builder) {
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