using IoBuilt.API.Devices.Domain.Model.Aggregates;

namespace IoBuilt.API.Analytics.Interfaces.ACL;

public interface IDevicesContextFacade
{
    Task<IEnumerable<Device>> GetDevicesByProjectIdAsync(int projectId);
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAsync(int deviceId);
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndTypeAsync(int deviceId, string type);
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAsync(int projectId);
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate);
    Task<int> CountDevicesByProjectIdAsync(int projectId);
    Task<int> CountDevicesByProjectIdAndStatusAsync(int projectId, string status);
}
