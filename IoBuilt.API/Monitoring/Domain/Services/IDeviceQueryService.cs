using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Monitoring.Domain.Model.Queries;

namespace IoBuilt.API.Monitoring.Domain.Services;

public interface IDeviceQueryService
{
    Task<IEnumerable<Device>> Handle(GetAllDevicesQuery query);
    Task<Device?> Handle(GetDeviceByIdQuery query);
}