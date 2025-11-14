namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

public record DeviceHealthStatusResource(
    int DeviceId,
    string DeviceName,
    string Type,
    string Status,
    double HealthPercentage
);
