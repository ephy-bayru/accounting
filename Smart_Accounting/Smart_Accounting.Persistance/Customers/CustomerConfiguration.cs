using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Customers;

namespace Smart_Accounting.Persistance.Customers
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> entity)
        {


            entity.ToTable("customers");

            entity.HasIndex(e => e.AccountId)
                .HasName("fk_customers_1_idx");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.FullName)
                .IsRequired()
                .HasColumnName("FULL_NAME")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.PhoneNo)
                .IsRequired()
                .HasColumnName("PHONE_NO")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.Country)
                .IsRequired()
                .HasColumnName("COUNTRY")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.City)
                .IsRequired()
                .HasColumnName("CITY")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.SubCity)
                .IsRequired()
                .HasColumnName("SUB_CITY")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.HouseNo)
                .IsRequired()
                .HasColumnName("HOUSE_NO")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasColumnName("POSTAL_CODE")
                .HasColumnType("varchar(45)");

            entity.Property(e => e.DateCreated)
                .HasColumnName("DATE_CREATED")
                .HasColumnType("datetime")
                .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

            entity.Property(e => e.DateUpdated)
                .HasColumnName("DATE_UPDATED")
                .HasColumnType("datetime")
                .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Customer)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customers_1");

        }
    }
}