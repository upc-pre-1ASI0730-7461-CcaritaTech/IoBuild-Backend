using IoBuilt.API.Devices.Domain.Model.Aggregates;

namespace IoBuilt.API.Analytics.Interfaces.ACL;

/// <summary>
/// Interface defining the Anti-Corruption Layer for Devices bounded context.
/// Provides methods for Analytics context to query device and device log information.
/// </summary>
public interface IDevicesContextFacade
{
    /// <summary>
    /// Retrieves all devices associated with a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Collection of devices in the project.</returns>
    Task<IEnumerable<Device>> GetDevicesByProjectIdAsync(int projectId);
    
    /// <summary>
    /// Retrieves all device logs for a specific device.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <returns>Collection of device logs.</returns>
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAsync(int deviceId);
    
    /// <summary>
    /// Retrieves device logs filtered by device ID and log type.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <param name="type">The type of log (e.g., "temperature", "energy").</param>
    /// <returns>Collection of filtered device logs.</returns>
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndTypeAsync(int deviceId, string type);
    
    /// <summary>
    /// Retrieves device logs within a specific date range for a device.
    /// </summary>
    /// <param name="deviceId">The device's unique identifier.</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>Collection of device logs within the date range.</returns>
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByDeviceIdAndDateRangeAsync(int deviceId, DateTime startDate, DateTime endDate);
    
    /// <summary>
    /// Retrieves all device logs for a specific project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Collection of device logs for the project.</returns>
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAsync(int projectId);
    
    /// <summary>
    /// Retrieves device logs within a specific date range for a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <param name="startDate">The start date of the range.</param>
    /// <param name="endDate">The end date of the range.</param>
    /// <returns>Collection of device logs within the date range.</returns>
    Task<IEnumerable<DeviceLog>> GetDeviceLogsByProjectIdAndDateRangeAsync(int projectId, DateTime startDate, DateTime endDate);
    
    /// <summary>
    /// Counts the total number of devices in a project.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <returns>Total device count.</returns>
    Task<int> CountDevicesByProjectIdAsync(int projectId);
    
    /// <summary>
    /// Counts devices in a project filtered by status.
    /// </summary>
    /// <param name="projectId">The project's unique identifier.</param>
    /// <param name="status">The device status to filter by (e.g., "Online", "Offline").</param>
    /// <returns>Count of devices matching the status.</returns>
    Task<int> CountDevicesByProjectIdAndStatusAsync(int projectId, string status);
}
