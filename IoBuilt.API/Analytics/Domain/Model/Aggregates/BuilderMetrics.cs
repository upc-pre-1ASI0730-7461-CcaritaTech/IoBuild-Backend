using IoBuilt.API.Analytics.Domain.Model.Entities;

namespace IoBuilt.API.Analytics.Domain.Model.Aggregates;

public class BuilderMetrics
{
    public int TotalDevices { get; set; }
    public int OnlineDevices { get; set; }
    public int OfflineDevices { get; set; }
    public int AlertsCount { get; set; }
    public int ActiveProjectsCount { get; set; }
    public int TotalUnits { get; set; }
    public int OccupiedUnits { get; set; }
    public double OccupancyRate { get; set; }
    public double EnergyEfficiencyAvg { get; set; }
    public List<HistoricalDataPoint> TemperatureHistory { get; set; } = new();
    public List<HistoricalDataPoint> EnergyHistory { get; set; } = new();
    public List<HistoricalDataPoint> HourlyEnergyData { get; set; } = new();
    public List<MonthlyOccupancyData> MonthlyOccupancy { get; set; } = new();
    public Dictionary<string, int> DevicesByType { get; set; } = new();
    public List<ProjectOverview> ProjectsOverview { get; set; } = new();
}
