using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Monitoring.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyMonitoringConfiguration(this ModelBuilder builder)
    {
        // Monitoring Context
        
        builder.Entity<Device>().HasKey(d => d.Id);
        builder.Entity<Device>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Device>().Property(d => d.Name).IsRequired().HasMaxLength(200);
        builder.Entity<Device>().Property(d => d.Type).IsRequired().HasMaxLength(100);
        builder.Entity<Device>().Property(d => d.Location).HasMaxLength(300);
        builder.Entity<Device>().Property(d => d.ProjectId).IsRequired();
        builder.Entity<Device>().Property(d => d.Status).IsRequired().HasMaxLength(50);
    }
}
