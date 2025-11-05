using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Devices.Domain.Repositories;

public interface IDevicesRepository : IBaseRepository<Device>
{
    Task<IEnumerable<Device>> FindByOwnerIdAsync(int ownerId);
    Task<IEnumerable<Device>> FindByStatusAsync(string status);
}