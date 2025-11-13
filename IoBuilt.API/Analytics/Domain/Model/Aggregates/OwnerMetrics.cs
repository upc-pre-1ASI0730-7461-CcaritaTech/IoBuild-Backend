using IoBuilt.API.Analytics.Domain.Model.Entities;

namespace IoBuilt.API.Analytics.Domain.Model.Aggregates;

public class OwnerMetrics
{
    public int TotalDevices { get; set; }
    public int OnlineDevices { get; set; }
    public int OfflineDevices { get; set; }
    public int AlertsCount { get; set; }
    public int MyUnitsCount { get; set; }
    public double EnergyThisMonth { get; set; }
    public double TemperatureAvg { get; set; }
    public double WaterUsageThisMonth { get; set; }
    public List<HistoricalDataPoint> TemperatureHistory { get; set; } = new();
    public List<HistoricalDataPoint> EnergyHistory { get; set; } = new();
    public List<HistoricalDataPoint> DailyEnergyConsumption { get; set; } = new();
    public List<HistoricalDataPoint> WaterUsageWeekly { get; set; } = new();
    public List<DeviceHealthStatus> DeviceHealthStatus { get; set; } = new();
    public List<UnitDetail> MyUnitsDetails { get; set; } = new();
}
