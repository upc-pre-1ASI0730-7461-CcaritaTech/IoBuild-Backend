namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record CreateProjectResource(string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, int BuilderId, string ImageUrl);
