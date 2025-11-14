namespace IoBuilt.API.Analytics.Domain.Model.Entities;

public class ProjectOverview
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int TotalUnits { get; set; }
    public int OccupiedUnits { get; set; }
    public double OccupancyRate { get; set; }
    public int DeviceCount { get; set; }
}
