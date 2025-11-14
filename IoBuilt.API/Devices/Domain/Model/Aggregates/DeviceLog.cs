namespace IoBuilt.API.Devices.Domain.Model.Aggregates;

public class DeviceLog
{
    public int Id { get; private set; }
    public int DeviceId { get; private set; }
    public DateTime Timestamp { get; private set; }
    public double Value { get; private set; }
    public string Type { get; private set; } = string.Empty;
    public string Metadata { get; private set; } = "{}";

    public DeviceLog(int deviceId, DateTime timestamp, double value, string type, string metadata = "{}")
    {
        DeviceId = deviceId;
        Timestamp = timestamp;
        Value = value;
        Type = type;
        Metadata = metadata;
    }

    protected DeviceLog() { }

    public void Update(double value, string type, string metadata)
    {
        Value = value;
        Type = type;
        Metadata = metadata;
    }
}
