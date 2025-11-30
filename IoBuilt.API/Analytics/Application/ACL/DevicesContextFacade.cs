using IoBuilt.API.Analytics.Interfaces.ACL;
using IoBuilt.API.Devices.Domain.Model.Aggregates;
using IoBuilt.API.Devices.Domain.Repositories;

namespace IoBuilt.API.Analytics.Application.ACL;

/// <summary>
/// Anti-Corruption Layer (ACL) facade for accessing Devices bounded context.
/// Translates and adapts Devices context operations for Analytics context consumption.
/// </summary>
public class DevicesContextFacade : IDevicesContextFacade
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IDeviceLogRepository _deviceLogRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DevicesContextFacade"/> class.
    /// </summary>
    /// <param name="deviceRepository">Repository for accessing device data.</param>
    /// <param name="deviceLogRepository">Repository for accessing device log data.</param>
    public DevicesContextFacade(IDeviceRepository deviceRepository, IDeviceLogRepository deviceLogRepository)
    {
        _deviceRepository = deviceRepository;
        _deviceLogRepository = deviceLogRepository;
    }

    /// <summary>
    /// Retrieves all devices associated with a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Collection of devices in the project.</returns>
    public async Task<IEnumerable<Device>> GetDevicesByProjectIdAsync(int projectId)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Where(d => d.ProjectId == projectId);
    }

    /// <summary>
    /// Retrieves all device logs for a specific device.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <returns>Collection of device logs.</returns>
    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAsync(int deviceId)
    {
        return await _deviceLogRepository.FindByDeviceIdAsync(deviceId);
    }

    /// <summary>
    /// Retrieves device logs filtered by device ID and log type.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <param name="type">The type of log (e.g., "temperature", "energy").</param>
    /// <returns>Collection of filtered device logs.</returns>
    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndTypeAsync(int deviceId, string type)
    {
        return await _deviceLogRepository.FindByDeviceIdAndTypeAsync(deviceId, type);
    }

    /// <summary>
    /// Retrieves device logs within a specific date range for a device.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>Collection of device logs within the date range.</returns>
    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate)
    {
        return await _deviceLogRepository.FindByDeviceIdAndDateRangeAsync(deviceId, startDate, endDate);
    }

    /// <summary>
    /// Retrieves all device logs for a specific project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Collection of device logs for the project.</returns>
    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAsync(int projectId)
    {
        return await _deviceLogRepository.FindByProjectIdAsync(projectId);
    }

    /// <summary>
    /// Retrieves device logs within a specific date range for a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>Collection of device logs within the date range.</returns>
    public async Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate)
    {
        return await _deviceLogRepository.FindByProjectIdAndDateRangeAsync(projectId, startDate, endDate);
    }

    /// <summary>
    /// Counts the total number of devices in a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Total device count.</returns>
    public async Task<int> CountDevicesByProjectIdAsync(int projectId)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Count(d => d.ProjectId == projectId);
    }

    /// <summary>
    /// Counts devices in a project filtered by status.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <param name="status">The device status to filter by (e.g., "Online", "Offline").</param>
    /// <returns>Count of devices matching the status.</returns>
    public async Task<int> CountDevicesByProjectIdAndStatusAsync(int projectId, string status)
    {
        var devices = await _deviceRepository.ListAsync();
        return devices.Count(d => d.ProjectId == projectId && d.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
    }
}
