using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Shared.Domain.Repositories;

namespace IoBuilt.API.Devices.Domain.Repositories;

public interface IDeviceLogRepository : IBaseRepository<DeviceLog>
{
    Task<IEnumerable<DeviceLog>> FindByDeviceIdAsync(int deviceId);
    Task<IEnumerable<DeviceLog>> FindByDeviceIdAndTypeAsync(int deviceId, string type);
    Task<IEnumerable<DeviceLog>> FindByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<DeviceLog>> FindByProjectIdAsync(int projectId);
    Task<IEnumerable<DeviceLog>> FindByProjectIdAndTypeAsync(int projectId, string type);
    Task<IEnumerable<DeviceLog>> FindByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate);
}
