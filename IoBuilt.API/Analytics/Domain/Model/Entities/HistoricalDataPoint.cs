namespace IoBuilt.API.Analytics.Domain.Model.Entities;

/// <summary>
/// Entity representing a single time-series data point for historical analytics.
/// Used to track temporal changes in metrics such as temperature, energy, or water usage.
/// </summary>
public class HistoricalDataPoint
{
    /// <summary>
    /// Gets or sets the timestamp when this data point was recorded.
    /// </summary>
    public DateTime Timestamp { get; set; }
    
    /// <summary>
    /// Gets or sets the measured value at this timestamp.
    /// </summary>
    public double Value { get; set; }
    
    /// <summary>
    /// Gets or sets the type/category of data (e.g., "temperature", "energy", "water").
    /// </summary>
    public string Type { get; set; } = string.Empty;
}
