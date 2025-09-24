using InternshipTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTask.Data.Configurations
{
    public class ScheduleConfigs : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(s => s.Date)
             .IsRequired();

            builder.Property(s => s.Status)
                   .IsRequired();

            builder.HasOne(s => s.Driver)
                .WithMany(d => d.Schedules)
                .HasForeignKey(s => s.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Route)
              .WithMany()
              .HasForeignKey(s => s.RouteId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.DriverId, s.Date })
                .IsUnique();
        }
    }
}
