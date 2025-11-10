using IoBuilt.API.Devices.Domain.Model.Commands;

namespace IoBuilt.API.Devices.Domain.Services;

public interface IDeviceCommandService
{
    Task<int> Handle(CreateDeviceCommand command);
    Task Handle(UpdateDeviceCommand command);
    Task Handle(DeleteDeviceCommand command);
}