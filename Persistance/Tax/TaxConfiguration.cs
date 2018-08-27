namespace Smart_Accounting.Persistance.Tax
{
    public class TaxConfiguration : EntityTypeConfiguration<Tax>
    {
        public TaxConfiguration() {


                ToTable("TAX");

                HasIndex(e => e.AccountId)
                    .HasName("fk_table1_account_idx");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.AccountId).HasColumnName("ACCOUNT_ID");

                Property(e => e.Amount).HasColumnName("amount");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();

                Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                HasOne(d => d.Account)
                    .WithMany(p => p.Tax)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_table1_account");
        }
    }
}