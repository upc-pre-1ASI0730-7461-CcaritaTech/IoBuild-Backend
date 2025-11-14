namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record CreateProjectCommand(string Name, string Description, string Location, int TotalUnits, int BuilderId, string ImageUrl);
