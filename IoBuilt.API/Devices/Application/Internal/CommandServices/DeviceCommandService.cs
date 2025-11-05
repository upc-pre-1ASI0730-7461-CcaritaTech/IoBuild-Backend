using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Commands;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Devices.Domain.Services;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Devices.Application.Internal.CommandServices;

public class DeviceCommandService(
    IDevicesRepository deviceRepository,
    IUnitOfWork unitOfWork) : IDeviceCommandService
{
    public async Task<Device?> Handle(CreateDeviceCommand command)
    {
        var device = await deviceRepository.FindByIdAsync(command.Id);
        if (device is not null) throw new Exception("Device already exists.");

        device = new Device(command);
        try
        {
            await deviceRepository.AddAsync(device);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return device;
    }
}