using IoBuilt.API.Devices.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IoBuilt.API.Devices.Infrastructure.Persistence.EFC.Configuration;

public class DeviceEntityConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.Location);
        builder.Property(x => x.ProjectId).IsRequired();
        builder.Property(x => x.Status).IsRequired();
    }
}