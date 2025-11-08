namespace IoBuilt.API.Devices.Domain.Model.Commands;

public record UpdateDeviceCommand(
    int Id,
    string Name,
    string Type,
    string Location,
    int ProjectId,
    string Status);