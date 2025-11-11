namespace IoBuilt.API.Devices.Domain.Model.Aggregates;

public class Device
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Type { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;
    
    public string MacAddress { get; private set; } = string.Empty;
    public int ProjectId { get; private set; }
    public string Status { get; private set; } = "Online";

    public Device(string name, string type, string location, string macAddress, int projectId, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        MacAddress = macAddress;
        ProjectId = projectId;
        Status = status ?? "Online";
    }


    public void Update(string name, string type, string location, int projectId, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        ProjectId = projectId;
        Status = status;
    }
}