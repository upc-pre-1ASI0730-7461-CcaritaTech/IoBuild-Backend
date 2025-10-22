namespace IoBuilt.API.Monitoring.Domain.Model.Aggregates;

/// <summary>
/// Device Aggregate Root
/// </summary>
public partial class Device
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Location { get; private set; }
    public int ProjectId { get; private set; }
    public string Status { get; private set; }

    public Device()
    {
        Name = string.Empty;
        Type = string.Empty;
        Location = string.Empty;
        Status = string.Empty;
    }
    
    public Device(string name, string type, string location, int projectId, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        ProjectId = projectId;
        Status = status;
    }
}