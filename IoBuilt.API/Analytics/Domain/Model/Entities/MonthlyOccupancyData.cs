namespace IoBuilt.API.Analytics.Domain.Model.Entities;

/// <summary>
/// Entity representing occupancy rate data for a specific month.
/// Used for tracking occupancy trends over time.
/// </summary>
public class MonthlyOccupancyData
{
    /// <summary>
    /// Gets or sets the month name (e.g., "Jan", "Feb").
    /// </summary>
    public string Month { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the occupancy rate as a percentage (0-100) for this month.
    /// </summary>
    public double OccupancyRate { get; set; }
    
    /// <summary>
    /// Gets or sets the year for this occupancy data point.
    /// </summary>
    public int Year { get; set; }
}
