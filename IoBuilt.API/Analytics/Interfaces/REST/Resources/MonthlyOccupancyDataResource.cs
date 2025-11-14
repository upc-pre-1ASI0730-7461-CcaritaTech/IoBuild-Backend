namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

public record MonthlyOccupancyDataResource(
    string Month,
    double OccupancyRate,
    int Year
);
