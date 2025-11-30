namespace IoBuilt.API.Analytics.Domain.Model.Entities;

/// <summary>
/// Entity representing the health and operational status of a device.
/// Provides insights into device reliability and performance.
/// </summary>
public class DeviceHealthStatus
{
    /// <summary>
    /// Gets or sets the unique identifier of the device.
    /// </summary>
    public int DeviceId { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the device.
    /// </summary>
    public string DeviceName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the type/category of the device (e.g., "Temperature", "Energy").
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the operational status of the device (e.g., "Online", "Offline").
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the health percentage of the device (0-100).
    /// Higher values indicate better device health and reliability.
    /// </summary>
    public double HealthPercentage { get; set; }
}
