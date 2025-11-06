using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Interfaces.REST.Resources;

namespace IoBuilt.API.Devices.Interfaces.REST.Transform;

public static class DeviceResourceFromEntityAssembler
{
    public static DeviceResource ToResource(Device device) =>
        new(device.Id, device.Name, device.Type, device.Location, device.Status);
}