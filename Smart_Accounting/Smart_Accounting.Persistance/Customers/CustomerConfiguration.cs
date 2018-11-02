using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Persistance.Customers {
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure (EntityTypeBuilder<Customer> builder) {
            builder.ToTable ("customer");

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
                .HasColumnName ("PHONE_NO")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.PostalCode)
                .HasColumnName ("POSTAL_CODE")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.SubCity)
                .HasColumnName ("SUB_CITY")
                .HasColumnType ("varchar(45)");
        }
    }
}