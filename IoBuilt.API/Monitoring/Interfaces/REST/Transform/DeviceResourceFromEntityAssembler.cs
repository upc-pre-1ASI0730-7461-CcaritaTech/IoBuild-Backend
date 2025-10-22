using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Monitoring.Interfaces.REST.Resources;

namespace IoBuilt.API.Monitoring.Interfaces.REST.Transform;

public static class DeviceResourceFromEntityAssembler
{
    public static DeviceResource ToResourceFromEntity(Device entity)
    {
        return new DeviceResource(
            entity.Id,
            entity.Name,
            entity.Type,
            entity.Location,
            entity.ProjectId,
            entity.Status);
    }
}