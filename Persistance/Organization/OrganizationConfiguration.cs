namespace Smart_Accounting.Persistance.Organization
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration() {

                ToTable("ORGANIZATION");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(45)");

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                Property(e => e.Organizationcol)
                    .HasColumnName("ORGANIZATIONcol")
                    .HasColumnType("varchar(10)");

                Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasColumnType("varchar(10)");

        }
    }
}