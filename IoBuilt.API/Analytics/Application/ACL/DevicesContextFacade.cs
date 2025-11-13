using IoBuilt.API.Analytics.Interfaces.ACL;
using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Repositories;

namespace IoBuilt.API.Analytics.Application.ACL;

public class DevicesContextFacade : IDevicesContextFacade
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IDeviceLogRepository _deviceLogRepository;

    public DevicesContextFacade(IDeviceRepository deviceRepository, IDeviceLogRepository deviceLogRepository)
    {
        _deviceRepository = deviceRepository;
        _deviceLogRepository = deviceLogRepository;
    }

    public async Task<IEnumerable<Device>> GetDevicesByProjectIdAsync(int projectId)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Where(d => d.ProjectId == projectId);
    }

    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAsync(int deviceId)
    {
        return await _deviceLogRepository.FindByDeviceIdAsync(deviceId);
    }

    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndTypeAsync(int deviceId, string type)
    {
        return await _deviceLogRepository.FindByDeviceIdAndTypeAsync(deviceId, type);
    }

    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate)
    {
        return await _deviceLogRepository.FindByDeviceIdAndDateRangeAsync(deviceId, startDate, endDate);
    }

    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAsync(int projectId)
    {
        return await _deviceLogRepository.FindByProjectIdAsync(projectId);
    }

    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate)
    {
        return await _deviceLogRepository.FindByProjectIdAndDateRangeAsync(projectId, startDate, endDate);
    }

    public async Task<int> CountDevicesByProjectIdAsync(int projectId)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Count(d => d.ProjectId == projectId);
    }

    public async Task<int> CountDevicesByProjectIdAndStatusAsync(int projectId, string status)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Count(d => d.ProjectId == projectId && d.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
    }
}
