using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Queries;
using IoBuilt.API.Devices.Domain.Repositories;
using IoBuilt.API.Devices.Domain.Services;
using IoBuilt.API.Monitoring.Domain.Repositories;
using IDeviceRepository = IoBuilt.API.Devices.Domain.Repositories.IDeviceRepository;

namespace IoBuilt.API.Devices.Application.Internal.QueryServices;

public class DeviceQueryService : IDeviceQueryService
{
    private readonly IDeviceRepository _repository;

    public DeviceQueryService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query)
        => await _repository.ListAsync();

    public async Task<Device?> Handle(GetDeviceByIdQuery query)
        => await _repository.FindByIdAsync(query.Id);
}