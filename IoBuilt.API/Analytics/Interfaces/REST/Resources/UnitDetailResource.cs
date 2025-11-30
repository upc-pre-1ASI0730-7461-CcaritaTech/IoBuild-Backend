namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing detailed information about a specific unit.
/// </summary>
/// <param name="UnitId">The unique identifier of the unit.</param>
/// <param name="UnitNumber">The unit number or identifier within the project.</param>
/// <param name="ProjectName">The name of the project this unit belongs to.</param>
/// <param name="ActiveDevices">The number of active devices in this unit.</param>
/// <param name="ConnectionStatus">The connection status of the unit.</param>
public record UnitDetailResource(
    int UnitId,
    string UnitNumber,
    string ProjectName,
    int ActiveDevices,
    string ConnectionStatus
);
