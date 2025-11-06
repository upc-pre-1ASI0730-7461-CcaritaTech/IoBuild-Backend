using IoBuilt.API.Devices.Domain.Model.Commands;
using IoBuilt.API.Devices.Interfaces.REST.Resources;

namespace IoBuilt.API.Devices.Interfaces.REST.Transform;

public static class DeviceResourceToCommandAssembler
{
    public static CreateDeviceCommand ToCommand(CreateDeviceResource resource) =>
        new(resource.Name, resource.Type, resource.Location, resource.Status);

    public static UpdateDeviceCommand ToCommand(int id, UpdateDeviceResource resource) =>
        new(id, resource.Name, resource.Type, resource.Location, resource.Status);
}