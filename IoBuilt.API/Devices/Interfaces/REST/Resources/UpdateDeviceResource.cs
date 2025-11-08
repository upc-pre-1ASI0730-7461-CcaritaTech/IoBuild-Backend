namespace IoBuilt.API.Devices.Interfaces.REST.Resources;


public record UpdateDeviceResource(
    string Name,
    string Type,
    string Location,
    int ProjectId,
    string Status);