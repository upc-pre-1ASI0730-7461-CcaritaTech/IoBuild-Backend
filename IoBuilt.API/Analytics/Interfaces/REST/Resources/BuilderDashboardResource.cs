namespace IoBuilt.API.Analytics.Interfaces.REST.Resources;

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
