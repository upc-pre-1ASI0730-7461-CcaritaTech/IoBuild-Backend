using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Model.Queries;

namespace IoBuilt.API.Devices.Domain.Services;

public interface IDeviceQueryService
{
    Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query);
    Task<Device?> Handle(GetDeviceByIdQuery query);
}