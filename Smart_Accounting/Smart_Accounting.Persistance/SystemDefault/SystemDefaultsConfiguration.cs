/*
 * @CreateTime: Nov 2, 2018 3:31 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:32 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.SystemDefault;

namespace Smart_Accounting.Persistance.Defaults {
    public class SystemDefaultConfiguration : IEntityTypeConfiguration<SystemDefaults> {
        public void Configure (EntityTypeBuilder<SystemDefaults> builder) {
            builder.ToTable ("system_defaults");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.Category)
                .IsRequired ()
                .HasColumnName ("category")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.DataType)
                .IsRequired ()
                .HasColumnName ("data_type")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Length)
                .IsRequired ()
                .HasColumnName ("length")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");
        }
    }
}