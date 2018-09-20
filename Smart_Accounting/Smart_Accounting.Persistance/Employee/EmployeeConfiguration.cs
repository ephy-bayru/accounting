using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Persistance.Employee {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees> {

        public void Configure (EntityTypeBuilder<Employees> builder) {
            builder.ToTable ("EMPLOYEES");

            builder.HasIndex (e => e.Account_Id)
                .HasName ("fk_EMPLOYEES_account_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Account_Id).HasColumnName ("ACCOUNT_ID");


            builder.Property (e => e.Date_Created)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.Date_Updated)
                .HasColumnName ("date_updated")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.First_Name)
                .IsRequired ()
                .HasColumnName ("FIRSTNAME")
                .HasColumnType ("varchar(45)");
            builder.Property (e => e.Last_Name)
                .IsRequired ()
                .HasColumnName ("LASTNAME")
                .HasColumnType ("varchar(45)");

        }
    }
}