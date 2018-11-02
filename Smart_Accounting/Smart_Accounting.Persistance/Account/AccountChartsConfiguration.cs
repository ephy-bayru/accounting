/*
 * @CreateTime: Nov 2, 2018 3:19 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:39 PM
 * @Description: Modify Here, Please 
 */
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.AccountCharts;

namespace Smart_Accounting.Persistance.AccountCharts {
    public class AccountsChartsConfiguration : IEntityTypeConfiguration<AccountChart> {
        public void Configure (EntityTypeBuilder<AccountChart> builder) {
            builder.HasKey (e => e.AccountId);

            builder.ToTable ("account_chart");

            builder.HasIndex (e => e.AccountId)
                .HasName ("ACCOUNT_ID_UNIQUE")
                .IsUnique ();

            builder.Property (e => e.AccountType)
                .HasColumnName ("account_type")
                .HasColumnType ("varchar(20)");
            
            builder.Property (e => e.Type)
                .HasColumnName ("type")
                .IsRequired()
                .HasColumnType ("varchar(20)");
            
            builder.Property (e => e.GlType)
                .IsRequired()
                .HasColumnName ("gl_type")
                .HasColumnType ("varchar(20)");

            builder.HasIndex (e => e.OrganizationId)
                .HasName ("fk_account_chart_organization_idx");

            builder.Property (e => e.AccountId)
                .HasColumnName ("ACCOUNT_ID")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.AccountCode)
                .HasColumnName ("account_code")
                .HasColumnType ("varchar(30)");

            builder.Property (e => e.Active)
                .HasColumnName ("active")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'1'");

            builder.Property (e => e.Closed)
                .HasColumnName ("closed")
                .HasColumnType ("tinyint(4)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.DirectPositng)
                .HasColumnName ("direct_positng")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.IsReconcilation)
                .HasColumnName ("is_reconcilation")
                .HasColumnType ("tinyint(1)")
                .HasDefaultValueSql ("'0'");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.OrganizationId).HasColumnName ("ORGANIZATION_ID");

            builder.HasOne (d => d.Organization)
                .WithMany (p => p.AccountChart)
                .HasForeignKey (d => d.OrganizationId)
                .OnDelete (DeleteBehavior.ClientSetNull)
                .HasConstraintName ("fk_account_chart_organization");
        }

    }
}