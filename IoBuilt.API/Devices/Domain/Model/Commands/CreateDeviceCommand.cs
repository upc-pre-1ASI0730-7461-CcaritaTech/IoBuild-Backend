namespace IoBuilt.API.Devices.Domain.Model.Commands;

public record CreateDeviceCommand(string Name, string Type, string Location, string Status);