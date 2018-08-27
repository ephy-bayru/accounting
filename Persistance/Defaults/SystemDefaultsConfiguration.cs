namespace Smart_Accounting.Persistance.Defaults
{
    public class SystemDefaultsConfiguration: EntityTypeConfiguration<SystemDefaults>
    {
        public SystemDefaultsConfiguration() {
            ToTable("system_defaults");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category")
                    .HasColumnType("varchar(45)");

                Property(e => e.DataType)
                    .IsRequired()
                    .HasColumnName("data_type")
                    .HasColumnType("varchar(45)");

                Property(e => e.Length)
                    .IsRequired()
                    .HasColumnName("length")
                    .HasColumnType("varchar(45)");

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");
        }
    }
}