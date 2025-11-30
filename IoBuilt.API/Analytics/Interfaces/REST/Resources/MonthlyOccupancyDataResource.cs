namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing occupancy rate data for a specific month.
/// </summary>
/// <param name="Month">The month name (e.g., "Jan", "Feb").</param>
/// <param name="OccupancyRate">The occupancy rate as a percentage (0-100).</param>
/// <param name="Year">The year for this occupancy data point.</param>
public record MonthlyOccupancyDataResource(
    string Month,
    double OccupancyRate,
    int Year
);
