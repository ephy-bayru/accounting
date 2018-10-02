using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Customers;

<<<<<<< HEAD
namespace Smart_Accounting.Persistance.Customers {
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure (EntityTypeBuilder<Customer> builder) {
            builder.ToTable ("customer");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_customer_account_idx");
=======
namespace Smart_Accounting.Persistance.Customers
{
    public class CustomersConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> entity)
        {
>>>>>>> 9ef68da30792e6e31c5afc6f3505b4fd316ec997


<<<<<<< HEAD
            builder.Property (e => e.AccountId)
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("varchar(30)");

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

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Customer)
                .HasForeignKey (d => d.AccountId)
                .HasConstraintName ("fk_customer_account");
=======
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

>>>>>>> 9ef68da30792e6e31c5afc6f3505b4fd316ec997
        }
    }
}