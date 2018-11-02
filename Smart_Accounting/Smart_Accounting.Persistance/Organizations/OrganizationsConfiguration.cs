/*
 * @CreateTime: Nov 2, 2018 3:30 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: Nov 2, 2018 3:30 PM
 * @Description: Modify Here, Please 
 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smart_Accounting.Domain.Oranizations;

namespace Smart_Accounting.Persistance.Organizations {
    public class OrganizationsConfiguration : IEntityTypeConfiguration<Organization> {
        public void Configure (EntityTypeBuilder<Organization> builder) {
            builder.ToTable ("organization");

            builder.Property (e => e.Id).HasColumnName ("ID");

            builder.Property (e => e.DateAdded)
                .HasColumnName ("date_added")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'");

            builder.Property (e => e.DateUpdated)
                .HasColumnName ("date_updated")
                .HasColumnType ("datetime")
                .HasDefaultValueSql ("'CURRENT_TIMESTAMP'")
                .ValueGeneratedOnAddOrUpdate ();

            builder.Property (e => e.Location)
                .HasColumnName ("location")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Name)
                .IsRequired ()
                .HasColumnName ("name")
                .HasColumnType ("varchar(45)");

            builder.Property (e => e.Organizationcol)
                .HasColumnName ("ORGANIZATIONcol")
                .HasColumnType ("varchar(10)");

            builder.Property (e => e.Tin)
                .HasColumnName ("TIN")
                .HasColumnType ("varchar(10)");
        }
    }
}