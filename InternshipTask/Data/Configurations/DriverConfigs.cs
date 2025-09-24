using InternshipTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTask.Data.Configurations
{
    public class DriverConfigs : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(D => D.Name).IsRequired().HasMaxLength(100);
            builder.Property(D => D.Phone).IsRequired().HasMaxLength(15);   
        }
    }
}
