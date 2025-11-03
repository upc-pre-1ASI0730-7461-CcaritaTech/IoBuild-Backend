namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record CreateProjectResource(int Id, string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, string Status, int BuilderId, DateTime CreatedDate, string ImageUrl);