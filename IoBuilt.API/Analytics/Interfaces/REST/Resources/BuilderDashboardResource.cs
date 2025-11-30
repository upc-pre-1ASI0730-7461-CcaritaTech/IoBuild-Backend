namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

/// <summary>
/// Resource representing comprehensive dashboard metrics for builder users.
/// Contains device statistics, project overviews, occupancy rates, and historical trends.
/// </summary>
/// <param name="TotalDevices">Total number of devices across all builder's projects.</param>
/// <param name="OnlineDevices">Count of devices currently online.</param>
/// <param name="OfflineDevices">Count of devices currently offline.</param>
/// <param name="AlertsCount">Total number of active alerts.</param>
/// <param name="ActiveProjectsCount">Number of active projects.</param>
/// <param name="TotalUnits">Total number of units across all projects.</param>
/// <param name="OccupiedUnits">Number of occupied units.</param>
/// <param name="OccupancyRate">Occupancy rate as a percentage.</param>
/// <param name="EnergyEfficiencyAvg">Average energy efficiency across all projects.</param>
/// <param name="TemperatureHistory">Temperature data for the last 30 days.</param>
/// <param name="EnergyHistory">Energy consumption data for the last 30 days.</param>
/// <param name="HourlyEnergyData">Hourly energy data for the last 24 hours.</param>
/// <param name="MonthlyOccupancy">Monthly occupancy trend for the last 6 months.</param>
/// <param name="DevicesByType">Device count grouped by device type.</param>
/// <param name="ProjectsOverview">Overview list of all projects with key metrics.</param>
public record BuilderDashboardResource(
    int TotalDevices,
    int OnlineDevices,
    int OfflineDevices,
    int AlertsCount,
    int ActiveProjectsCount,
    int TotalUnits,
    int OccupiedUnits,
    double OccupancyRate,
    double EnergyEfficiencyAvg,
    IEnumerable<HistoricalDataPointResource> TemperatureHistory,
    IEnumerable<HistoricalDataPointResource> EnergyHistory,
    IEnumerable<HistoricalDataPointResource> HourlyEnergyData,
    IEnumerable<MonthlyOccupancyDataResource> MonthlyOccupancy,
    Dictionary<string, int> DevicesByType,
    IEnumerable<ProjectOverviewResource> ProjectsOverview
);
