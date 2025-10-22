namespace IoBuilt.API.Monitoring.Interfaces.REST.Resources;

public record DeviceResource(
    int Id,
    string Name,
    string Type,
    string Location,
    int ProjectId,
    string Status);