using IoBuilt.API.Analytics.Domain.Model.Entities;

namespace IoBuilt.API.Analytics.Domain.Model.Aggregates;

/// <summary>
/// Aggregate root representing comprehensive analytics metrics for property owner users.
/// This aggregate consolidates device health, energy consumption, water usage,
/// temperature monitoring, and unit details for all units owned by a specific owner.
/// </summary>
public class OwnerMetrics
{
    /// <summary>
    /// Gets or sets the total number of devices across all owner's units.
    /// </summary>
    public int TotalDevices { get; set; }
    
    /// <summary>
    /// Gets or sets the count of devices currently in online/connected status.
    /// </summary>
    public int OnlineDevices { get; set; }
    
    /// <summary>
    /// Gets or sets the count of devices currently in offline/disconnected status.
    /// </summary>
    public int OfflineDevices { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of active alerts or issues requiring attention.
    /// Typically corresponds to offline devices or anomalies.
    /// </summary>
    public int AlertsCount { get; set; }
    
    /// <summary>
    /// Gets or sets the number of units owned by this owner.
    /// </summary>
    public int MyUnitsCount { get; set; }
    
    /// <summary>
    /// Gets or sets the total energy consumption for the current month (last 30 days).
    /// </summary>
    public double EnergyThisMonth { get; set; }
    
    /// <summary>
    /// Gets or sets the average temperature across all owner's units.
    /// </summary>
    public double TemperatureAvg { get; set; }
    
    /// <summary>
    /// Gets or sets the total water usage for the current month (last 30 days).
    /// </summary>
    public double WaterUsageThisMonth { get; set; }
    
    /// <summary>
    /// Gets or sets the historical temperature data points for the last 30 days.
    /// Used for trend visualization and analysis.
    /// </summary>
    public List<HistoricalDataPoint> TemperatureHistory { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the historical energy consumption data points for the last 30 days.
    /// </summary>
    public List<HistoricalDataPoint> EnergyHistory { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the daily energy consumption data for the last 30 days.
    /// Provides granular daily energy usage patterns.
    /// </summary>
    public List<HistoricalDataPoint> DailyEnergyConsumption { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the water usage data for the last 7 days.
    /// </summary>
    public List<HistoricalDataPoint> WaterUsageWeekly { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the health status of all devices across owner's units.
    /// Includes health percentage and operational status.
    /// </summary>
    public List<DeviceHealthStatus> DeviceHealthStatus { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the detailed information for each unit owned by this owner.
    /// Includes unit identification, project association, and device counts.
    /// </summary>
    public List<UnitDetail> MyUnitsDetails { get; set; } = new();
}
