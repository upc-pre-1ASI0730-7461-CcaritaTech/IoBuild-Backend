namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record CreateProjectCommand(string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, int BuilderId, string ImageUrl);
