using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Commands;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Devices.Domain.Services;
//using IoBuilt.API.Monitoring.Domain.Repositories;
using IDeviceRepository = IoBuilt.API.Devices.Domain.Repositories.IDeviceRepository;

namespace IoBuilt.API.Devices.Application.Internal.CommandServices;

public class DeviceCommandService : IDeviceCommandService
{
    private readonly IDeviceRepository _repository;

    public DeviceCommandService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateDeviceCommand command)
    {
        var device = new Device(command.Name, command.Type, command.Location, command.Status);
        await _repository.AddAsync(device);
        await _repository.SaveChangesAsync();
        return device.Id;
    }

    public async Task Handle(UpdateDeviceCommand command)
    {
        var device = await _repository.FindByIdAsync(command.Id) ?? throw new Exception("Device not found");
        device.Update(command.Name, command.Type, command.Location, command.Status);
        _repository.Update(device);
        await _repository.SaveChangesAsync();
    }

    public async Task Handle(DeleteDeviceCommand command)
    {
        var device = await _repository.FindByIdAsync(command.Id) ?? throw new Exception("Device not found");
        _repository.Remove(device);
        await _repository.SaveChangesAsync();
    }
}