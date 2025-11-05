using IoBuilt.API.Devices.Domain.Model.Commands;

namespace IoBuilt.API.Devices.Domain.Model.Aggregates;

public partial class Device
{
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Location { get; private set; }
    public string Status { get; private set; }

    public Device()
    {
        Name = string.Empty;
        Type = string.Empty;
        Location = string.Empty;
        Status = string.Empty;
    }

    public Device(string name, string type, string location, string status)
    {
        Name = name;
        Type = type;
        Location = location;
        Status = status;
    }

    public Device(CreateDeviceCommand command)
    {
        Name = command.Name;
        Type = command.Type;
        Location = command.Location;
        Status = command.Status;
    }
}