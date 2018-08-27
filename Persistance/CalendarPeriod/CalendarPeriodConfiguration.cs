namespace Smart_Accounting.Persistance.CalendarPeriod
{
    public class CalendarPeriodConfiguration : EntityTypeConfiguration<CalendarPeriod>
    {

        public CalendarPeriodConfiguration() {

                HasKey(e => e.PeriodId);

                ToTable("calendar_period");

                Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("date");

                Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("date");
        }
        
    }
}