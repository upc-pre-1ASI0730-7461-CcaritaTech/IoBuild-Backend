namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record UpdateProjectCommand(int Id, string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, string Status, int BuilderId, string ImageUrl);
