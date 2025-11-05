namespace IoBuilt.API.Devices.Domain.Model.Aggregates;

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Type { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    public int ProjectId { get; private set; }
    public string Status { get; private set; } = string.Empty;

    public Device(string name, string type, string location, int projectId, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        ProjectId = projectId;
        Status = status;
    }

    public Device(string commandName, string commandType, string commandLocation, string commandStatus)
    {
        throw new NotImplementedException();
    }

    public void Update(string name, string type, string location, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        Status = status;
    }
}