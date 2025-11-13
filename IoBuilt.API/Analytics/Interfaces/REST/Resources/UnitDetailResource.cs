namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

public record UnitDetailResource(
    int UnitId,
    string UnitNumber,
    string ProjectName,
    int ActiveDevices,
    string ConnectionStatus
);
