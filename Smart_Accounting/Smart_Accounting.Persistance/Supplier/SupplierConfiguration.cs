/*
 * @CreateTime: Oct 9, 2018 9:32 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:31 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Supplier;

namespace Smart_Accounting.Persistance.Supplier {
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers> {
        public void Configure (EntityTypeBuilder<Suppliers> builder) {

            builder.ToTable ("suppliers");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.City)
                .HasColumnName ("CITY")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Country)
                .HasColumnName ("COUNTRY")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DateCreated)
                .HasColumnName ("DATE_CREATED")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("DATE_UPDATED")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Email)
                .IsRequired ()
                .HasColumnName ("EMAIL")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.FullName)
                .IsRequired ()
                .HasColumnName ("FULL_NAME")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.HouseNo)
                .HasColumnName ("HOUSE_NO")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.PhoneNo)
                .IsRequired ()
                .HasColumnName ("PHONENO")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.PostalCode)
                .HasColumnName ("POSTAL_CODE")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.SubCity)
                .HasColumnName ("SUB_CITY")
                .HasColumnType ("varchar(30)");

             builder.Property (e => e.Balance)
                .HasColumnName ("balance")
                .HasColumnType ("FLOAT")
                .HasDefaultValueSql ("'0'");

             builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

        }
    }
}