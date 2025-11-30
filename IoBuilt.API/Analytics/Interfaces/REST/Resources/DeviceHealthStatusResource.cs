namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing device health and operational status.
/// </summary>
/// <param name="DeviceId">The unique identifier of the device.</param>
/// <param name="DeviceName">The name of the device.</param>
/// <param name="Type">The type/category of the device.</param>
/// <param name="Status">The operational status of the device.</param>
/// <param name="HealthPercentage">The health percentage of the device (0-100).</param>
public record DeviceHealthStatusResource(
    int DeviceId,
    string DeviceName,
    string Type,
    string Status,
    double HealthPercentage
);
