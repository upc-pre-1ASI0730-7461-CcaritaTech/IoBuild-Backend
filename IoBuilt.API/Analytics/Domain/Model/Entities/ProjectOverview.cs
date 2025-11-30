namespace IoBuilt.API.Analytics.Domain.Model.Entities;

/// <summary>
/// Entity representing a summary overview of a project's key metrics.
/// Provides consolidated project information for analytics dashboards.
/// </summary>
public class ProjectOverview
{
    /// <summary>
    /// Gets or sets the unique identifier of the project.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the project.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the location of the project.
    /// </summary>
    public string Location { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the current status of the project (e.g., "Active", "OnGoing", "Completed").
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the total number of units in the project.
    /// </summary>
    public int TotalUnits { get; set; }
    
    /// <summary>
    /// Gets or sets the number of occupied units in the project.
    /// </summary>
    public int OccupiedUnits { get; set; }
    
    /// <summary>
    /// Gets or sets the occupancy rate as a percentage (0-100).
    /// </summary>
    public double OccupancyRate { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of devices deployed in the project.
    /// </summary>
    public int DeviceCount { get; set; }
}
