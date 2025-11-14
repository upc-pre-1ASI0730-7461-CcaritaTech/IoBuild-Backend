using IoBuilt.API.Devices.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyDevicesConfiguration(this ModelBuilder builder)
    {
        
        builder.Entity<Device>().HasKey(x => x.Id);
        builder.Entity<Device>().Property(x => x.Name).IsRequired();
        builder.Entity<Device>().Property(x => x.Type).IsRequired();
        builder.Entity<Device>().Property(x => x.Location);
        builder.Entity<Device>().Property(x => x.MacAddress).IsRequired();
        builder.Entity<Device>().Property(x => x.ProjectId).IsRequired();
        builder.Entity<Device>().Property(x => x.Status).IsRequired();

        // DeviceLog Configuration
        builder.Entity<DeviceLog>().ToTable("device_logs");
        builder.Entity<DeviceLog>().HasKey(x => x.Id);
        builder.Entity<DeviceLog>().Property(x => x.DeviceId).IsRequired();
        builder.Entity<DeviceLog>().Property(x => x.Timestamp).IsRequired();
        builder.Entity<DeviceLog>().Property(x => x.Value).IsRequired();
        builder.Entity<DeviceLog>().Property(x => x.Type).IsRequired();
        builder.Entity<DeviceLog>().Property(x => x.Metadata).IsRequired();
    }
}