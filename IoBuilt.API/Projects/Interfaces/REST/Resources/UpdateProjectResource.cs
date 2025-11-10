namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record UpdateProjectResource(string Name, string Description, string Location, int TotalUnits, int OccupiedUnits, string Status, int BuilderId, string ImageUrl);
