using IoBuilt.API.Projects.Domain.Model.ValueObjects;

namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record UpdateProjectCommand(int Id, string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, EProjectStatus Status, int BuilderId, string ImageUrl);
