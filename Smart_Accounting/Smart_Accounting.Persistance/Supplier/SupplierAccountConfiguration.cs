/*
 * @CreateTime: Oct 9, 2018 9:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Oct 9, 2018 9:58 AM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Persistance.Supplier {
    public class SupplierAccountConfiguration : IEntityTypeConfiguration<SupplierAccount> {
        public void Configure (EntityTypeBuilder<SupplierAccount> builder) {
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