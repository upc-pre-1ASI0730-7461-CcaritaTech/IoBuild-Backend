namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

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
