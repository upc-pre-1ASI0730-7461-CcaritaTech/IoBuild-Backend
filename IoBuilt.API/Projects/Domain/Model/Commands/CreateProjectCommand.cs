namespace IoBuilt.API.Projects.Domain.Model.Commands;

public record CreateProjectCommand(int Id, string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, string Status, int BuilderId, DateTime CreatedDate, string ImageUrl);