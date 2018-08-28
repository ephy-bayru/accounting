using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain;
namespace Smart_Accounting.Persistance.CalendarPeriods
{
    public class CalendarPeriodConfiguration : IEntityTypeConfiguration<CalendarPeriod>
    {

        public void Configure(EntityTypeBuilder<CalendarPeriod> builder)
        {
            
                builder.HasKey(e => e.PeriodId);

                builder.ToTable("calendar_period");

                builder.Property(e => e.PeriodId).HasColumnName("PERIOD_ID");

                builder.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("tinyint(4)");

                builder.Property(e => e.End)
                    .HasColumnName("end")
                    .HasColumnType("date");

                builder.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("date");
        }

    }
}