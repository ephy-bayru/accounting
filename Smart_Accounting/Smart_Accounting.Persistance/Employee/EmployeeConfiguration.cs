using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Employe;

namespace Smart_Accounting.Persistance.Employee {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employees> {

        public void Configure (EntityTypeBuilder<Employees> builder) {
            builder.ToTable ("EMPLOYEES");

            builder.HasIndex (e => e.AccountId)
                .HasName ("fk_EMPLOYEES_account_idx");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.AccountId).HasColumnName ("ACCOUNT_ID");

            builder.Property (e => e.CreditLimit).HasColumnName ("credit_limit");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("NAME")
                .HasColumnType ("varchar(45)");

            builder.HasOne (d => d.Account)
                .WithMany (p => p.Employees)
                .HasForeignKey (d => d.AccountId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_EMPLOYEES_account");
                
        }
    }
}