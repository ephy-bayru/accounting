namespace Smart_Accounting.Persistance.Ledger
{
    public class LedgerConfiguration : EntityTypeConfiguration<Ledger> 
    {
        public LedgerConfiguration() {
            ToTable("LEDGER");

                HasIndex(e => e.PeriodId)
                    .HasName("fk_LEDGER_PERIOD_idx");

                Property(e => e.Id).HasColumnName("ID");

                Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("datetime");

                Property(e => e.Discription)
                    .IsRequired()
                    .HasColumnName("discription")
                    .HasColumnType("varchar(45)");

                Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                HasOne(d => d.Period)
                    .WithMany(p => p.Ledger)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LEDGER_PERIOD");
        }
    }
}