using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Commands;

namespace IoBuilt.API.Devices.Domain.Services;

public interface IDeviceCommandService
{
    Task<Device?> Handle(CreateDeviceCommand command);
}