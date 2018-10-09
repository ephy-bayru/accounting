using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Persistance.Employee {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees> {

        public void Configure (EntityTypeBuilder<Employees> entity) {

            entity.ToTable ("employees");

            entity.Property (e => e.Id).HasColumnName ("ID");

            entity.Property (e => e.BirthDate)
                .HasColumnName ("BIRTH_DATE")
                .HasColumnType ("datetime");

            entity.Property (e => e.DateCreated)
                .HasColumnName ("DATE_CREATED")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            entity.Property (e => e.DateUpdated)
                .HasColumnName ("DATE_UPDATED")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            entity.Property (e => e.Email)
                .IsRequired ()
                .HasColumnName ("EMAIL")
                .HasColumnType ("varchar(45)");

            entity.Property (e => e.FirstName)
                .IsRequired ()
                .HasColumnName ("FIRST_NAME")
                .HasColumnType ("varchar(45)");

            entity.Property (e => e.Gender)
                .IsRequired ()
                .HasColumnName ("GENDER")
                .HasColumnType ("char(5)");

            entity.Property (e => e.LastName)
                .IsRequired ()
                .HasColumnName ("LAST_NAME")
                .HasColumnType ("varchar(45)");

            entity.Property (e => e.Password)
                .IsRequired ()
                .HasColumnName ("PASSWORD")
                .HasColumnType ("varchar(45)");

            entity.Property (e => e.PhoneNo)
                .IsRequired ()
                .HasColumnName ("PHONE_NO")
                .HasColumnType ("varchar(45)");

        }
    }
}