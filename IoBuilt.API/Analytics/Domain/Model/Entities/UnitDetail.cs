namespace IoBuilt.API.Analytics.Domain.Model.Entities;

/// <summary>
/// Entity representing detailed information about a specific unit.
/// Provides unit-level metrics including device count and connectivity status.
/// </summary>
public class UnitDetail
{
    /// <summary>
    /// Gets or sets the unique identifier of the unit.
    /// </summary>
    public int UnitId { get; set; }
    
    /// <summary>
    /// Gets or sets the unit number or identifier within the project.
    /// </summary>
    public string UnitNumber { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the name of the project this unit belongs to.
    /// </summary>
    public string ProjectName { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the number of active devices in this unit.
    /// </summary>
    public int ActiveDevices { get; set; }
    
    /// <summary>
    /// Gets or sets the connection status of the unit (e.g., "Connected", "Disconnected").
    /// </summary>
    public string ConnectionStatus { get; set; } = string.Empty;
}
