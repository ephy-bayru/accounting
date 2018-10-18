using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Persistance.Employee {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees> {

        public void Configure (EntityTypeBuilder<Employees> builder) {

            builder.ToTable ("employees");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.BirthDate)
                .HasColumnName ("BIRTH_DATE")
                .HasColumnType ("datetime");

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

            builder.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("FIRST_NAME")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Gender)
                .IsRequired ()
                .HasColumnName ("GENDER")
                .HasColumnType ("char(5)");

            builder.Property (e => e.LastName)
                .IsRequired ()
                .HasColumnName ("LAST_NAME")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Password)
                .IsRequired ()
                .HasColumnName ("PASSWORD")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Phone_No)
                .IsRequired ()
                .HasColumnName ("PHONE_NO")
                .HasColumnType ("varchar(45)");

        }
    }
}