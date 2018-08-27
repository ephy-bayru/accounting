using System.Linq;

namespace Smart_Accounting.Persistance.Account.AccountChart
{
    public class AccountChartConfiguration :EntityTypeConfiguration<AccountChart> 
    {
        public AccountChartConfiguration()
        {
                HasKey(e => e.AccountId);

                    ToTable("account_chart");

                    HasIndex(e => e.AccountCode)
                    .HasName("account_code_UNIQUE")
                    .IsUnique();

                    HasIndex(e => e.AccountType)
                    .HasName("fk_account_chart_type_idx");

                    HasIndex(e => e.OrganizationId)
                    .HasName("fk_account_chart_organization_idx");

                    HasIndex(e => e.SubAccountCode)
                    .HasName("fk_account_chart_parent_idx");

                    Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                    Property(e => e.AccountCategoryAccCatId)
                    .HasColumnName("account_category_acc_cat_id")
                    .HasColumnType("int(11)");

                    Property(e => e.AccountCode)
                    .IsRequired()
                    .HasColumnName("account_code")
                    .HasColumnType("varchar(30)");

                    Property(e => e.AccountType).HasColumnName("account_type");

                    Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                    Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                    Property(e => e.OrganizationId).HasColumnName("ORGANIZATION_ID");

                    Property(e => e.SubAccountCode)
                    .HasColumnName("sub_account_code")
                    .HasColumnType("varchar(45)");

                    HasOne(d => d.AccountTypeNavigation)
                    .WithMany(p => p.AccountChart)
                    .HasForeignKey(d => d.AccountType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_chart_type");

                    HasOne(d => d.Organization)
                    .WithMany(p => p.AccountChart)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_account_chart_organization");

                    HasOne(d => d.SubAccountCodeNavigation)
                    .WithMany(p => p.InverseSubAccountCodeNavigation)
                    .HasPrincipalKey(p => p.AccountCode)
                    .HasForeignKey(d => d.SubAccountCode)
                    .HasConstraintName("fk_account_chart_parent");

        }        
    }
}