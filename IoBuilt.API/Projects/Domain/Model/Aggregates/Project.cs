using IoBuilt.API.Projects.Domain.Model.Commands;
using IoBuilt.API.Projects.Domain.Model.ValueObjects;

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
    public EProjectStatus Status { get; private set; }
    public int BuilderId { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public string ImageUrl { get; private set; }

    public Project()
    {
        Name = string.Empty;
        Description = string.Empty;
        Location = string.Empty;
        Status = EProjectStatus.Planned;
        ImageUrl = string.Empty;
    }
    
    public Project(string name, string description, string location, int totalUnits, int occupiedUnits, EProjectStatus status, int builderId, DateTime createdDate, string imageUrl)
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

    public Project(CreateProjectCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Location = command.Location;
        TotalUnits = command.TotalUnits;
        OccupiedUnits = 0;
        Status = EProjectStatus.Planned;
        BuilderId = command.BuilderId;
        CreatedDate = new DateTime();
        ImageUrl = command.ImageUrl;
    }

    public Project Update(UpdateProjectCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Location = command.Location;
        TotalUnits = command.TotalUnits;
        OccupiedUnits = command.OccupiedUnits;
        Status = command.Status;
        BuilderId = command.BuilderId;
        ImageUrl = command.ImageUrl;
        return this;
    }
}