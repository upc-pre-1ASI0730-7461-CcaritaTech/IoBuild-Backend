using IoBuilt.API.Monitoring.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Monitoring.Domain.Repositories;

public interface IDeviceRepository : IBaseRepository<Device>
{
    Task<IEnumerable<Device>> FindByProjectIdAsync(int projectId);
    Task<IEnumerable<Device>> FindByStatusAsync(string status);
    Task<IEnumerable<Device>> FindByTypeAsync(string type);
}