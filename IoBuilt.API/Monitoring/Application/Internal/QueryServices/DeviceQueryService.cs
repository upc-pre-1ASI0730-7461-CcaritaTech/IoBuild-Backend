using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Monitoring.Domain.Model.Queries;
using IoBuilt.API.Monitoring.Domain.Repositories;
using IoBuilt.API.Monitoring.Domain.Services;

namespace IoBuilt.API.Monitoring.Application.Internal.QueryServices;

public class DeviceQueryService(IDeviceRepository deviceRepository) : IDeviceQueryService
{
    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query)
    {
        return await deviceRepository.ListAsync();
    }

    public async Task<Device?> Handle(GetDeviceByIdQuery query)
    {
        return await deviceRepository.FindByIdAsync(query.DeviceId);
    }
}