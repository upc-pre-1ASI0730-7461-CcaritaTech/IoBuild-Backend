using IoBuilt.API.Analytics.Domain.Model.Entities;

namespace IoBuilt.API.Analytics.Domain.Model.Aggregates;

/// <summary>
/// Aggregate root representing comprehensive analytics metrics for builder users.
/// This aggregate consolidates device statistics, project overviews, occupancy rates,
/// energy efficiency data, and historical trends across all projects managed by a builder.
/// </summary>
public class BuilderMetrics
{
    /// <summary>
    /// Gets or sets the total number of devices across all builder's projects.
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
    /// Gets or sets the number of projects currently in active state.
    /// </summary>
    public int ActiveProjectsCount { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of units across all projects.
    /// </summary>
    public int TotalUnits { get; set; }
    
    /// <summary>
    /// Gets or sets the number of units that are currently occupied.
    /// </summary>
    public int OccupiedUnits { get; set; }
    
    /// <summary>
    /// Gets or sets the occupancy rate as a percentage (0-100).
    /// Calculated as (OccupiedUnits / TotalUnits) * 100.
    /// </summary>
    public double OccupancyRate { get; set; }
    
    /// <summary>
    /// Gets or sets the average energy efficiency across all projects.
    /// </summary>
    public double EnergyEfficiencyAvg { get; set; }
    
    /// <summary>
    /// Gets or sets the historical temperature data points for the last 30 days.
    /// Used for trend visualization and analysis.
    /// </summary>
    public List<HistoricalDataPoint> TemperatureHistory { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the historical energy consumption data points for the last 30 days.
    /// Represents daily energy totals.
    /// </summary>
    public List<HistoricalDataPoint> EnergyHistory { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the hourly energy consumption data for the last 24 hours.
    /// Provides granular short-term energy usage patterns.
    /// </summary>
    public List<HistoricalDataPoint> HourlyEnergyData { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the monthly occupancy trend data for the last 6 months.
    /// </summary>
    public List<MonthlyOccupancyData> MonthlyOccupancy { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the device count grouped by device type (e.g., Temperature, Energy, HVAC).
    /// Key represents the device type, value represents the count.
    /// </summary>
    public Dictionary<string, int> DevicesByType { get; set; } = new();
    
    /// <summary>
    /// Gets or sets the overview list of all projects with key metrics.
    /// </summary>
    public List<ProjectOverview> ProjectsOverview { get; set; } = new();
}
