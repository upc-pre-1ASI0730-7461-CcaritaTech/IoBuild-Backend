namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing a summary overview of a project's key metrics.
/// </summary>
/// <param name="Id">The unique identifier of the project.</param>
/// <param name="Name">The name of the project.</param>
/// <param name="Location">The location of the project.</param>
/// <param name="Status">The current status of the project.</param>
/// <param name="TotalUnits">The total number of units in the project.</param>
/// <param name="OccupiedUnits">The number of occupied units in the project.</param>
/// <param name="OccupancyRate">The occupancy rate as a percentage (0-100).</param>
/// <param name="DeviceCount">The total number of devices deployed in the project.</param>
public record ProjectOverviewResource(
    int Id,
    string Name,
    string Location,
    string Status,
    int TotalUnits,
    int OccupiedUnits,
    double OccupancyRate,
    int DeviceCount
);
