namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record ProjectResource(
    int Id,
    string Name,
    string Description,
    string Location,
    int TotalUnits,
    int OccupiedUnits,
    string Status,
    int BuilderId,
    DateTime CreatedDate,
    string ImageUrl);