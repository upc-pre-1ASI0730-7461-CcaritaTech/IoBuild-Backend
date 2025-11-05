namespace IoBuilt.API.Devices.Interfaces.REST.Resources;

public record CreateDeviceResource(
    string Name,
    string Type,
    string Location,
    string Status);