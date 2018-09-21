using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Persistance.Employee
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees>
    {

        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("EMPLOYEES");

            builder.Property(e => e.Id)
            .HasColumnName("ID");

            builder.Property(e => e.First_Name)
                .IsRequired()
                .HasColumnName("FIRST_NAME")
                .HasColumnType("varchar(45)");

            builder.Property(e => e.Last_Name)
                .IsRequired()
                .HasColumnName("LAST_NAME")
                .HasColumnType("varchar(45)");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasColumnType("VARCHAR(45)");

            builder.Property(e => e.Phone_No)
                .IsRequired()
                .HasColumnType("VARCHAR(45)")
                .HasColumnName("PHONE_NO");

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasColumnType("CHAR(5)")
                .HasColumnName("GENDER");


            builder.Property(e => e.Account_Id)
                .IsRequired()
                .HasColumnName("ACCOUNT_ID")
                .HasColumnType("VARCHAR(45)");

            // builder.HasIndex(e => e.Account_Id)
            //     .HasName("fk_employees_1");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("PASSWORD")
                .HasColumnType("VARCHAR(45)");

            builder.Property(e => e.Birth_Date)
                .HasColumnName("BIRTH_DATE")
                .HasColumnType("datetime");

            builder.Property(e => e.Date_Created)
                .HasColumnName("DATE_CREATED")
                .HasColumnType("datetime")
                .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

            builder.Property(e => e.Date_Updated)
                .HasColumnName("DATE_UPDATED")
                .HasColumnType("'CURRENT_TIMESTAMP'");

        }
    }
}