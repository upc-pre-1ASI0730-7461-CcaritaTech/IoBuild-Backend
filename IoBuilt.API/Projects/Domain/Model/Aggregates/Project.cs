namespace IoBuilt.API.Projects.Domain.Model.Aggregates;

/// <summary>
/// Project Aggregate Root
/// </summary>
public partial class Project
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public int TotalUnits { get; private set; }
    public int OccupiedUnits { get; private set; }
    public string Status { get; private set; }
    public int BuilderId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ImageUrl { get; private set; }

    public Project()
    {
        Name = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Status = string.Empty;
        ImageUrl = string.Empty;
    }
    
    public Project(string name, string description, string location, int totalUnits, int occupiedUnits, string status, int builderId, DateTime createdDate, string imageUrl)
    {
        Name = name;
        Description = description;
        Location = location;
        TotalUnits = totalUnits;
        OccupiedUnits = occupiedUnits;
        Status = status;
        BuilderId = builderId;
        CreatedDate = createdDate;
        ImageUrl = imageUrl;
    }
}