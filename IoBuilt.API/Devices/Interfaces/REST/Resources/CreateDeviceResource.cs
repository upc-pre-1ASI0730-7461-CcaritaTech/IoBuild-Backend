namespace IoBuilt.API.Devices.Interfaces.REST.Resources;

public record CreateDeviceResource(
    string Name,
    string Type,
    string Location,
    int ProjectId,
    string Status);