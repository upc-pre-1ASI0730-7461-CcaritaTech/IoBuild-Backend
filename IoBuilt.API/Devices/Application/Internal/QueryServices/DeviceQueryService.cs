using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Queries;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Devices.Domain.Services;

namespace IoBuilt.API.Devices.Application.Internal.QueryServices;

public class DeviceQueryService(IDevicesRepository deviceRepository) : IDeviceQueryService
{
    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query)
    {
        return await deviceRepository.ListAsync();
    }

    public Task<Device?> Handle(GetDeviceByIdQuery query)
    {
        return await deviceRepository.FindByIdAsync(query.DeviceId)
    }
}