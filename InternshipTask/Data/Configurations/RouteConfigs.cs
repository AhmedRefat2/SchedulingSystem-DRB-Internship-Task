using InternshipTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTask.Data.Configurations
{
    public class RouteConfigs : IEntityTypeConfiguration<Models.Route>
    {
        public void Configure(EntityTypeBuilder<Models.Route> builder)
        {
            builder.Property(r => r.StartLocation)
             .IsRequired()
             .HasMaxLength(150);

            builder.Property(r => r.EndLocation)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(r => r.Date)
                   .IsRequired();
        }
    }
}
