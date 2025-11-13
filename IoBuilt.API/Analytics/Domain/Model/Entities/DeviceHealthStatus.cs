namespace IoBuilt.API.Analytics.Domain.Model.Entities;

public class DeviceHealthStatus
{
    public int DeviceId { get; set; }
    public string DeviceName { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public double HealthPercentage { get; set; }
}
