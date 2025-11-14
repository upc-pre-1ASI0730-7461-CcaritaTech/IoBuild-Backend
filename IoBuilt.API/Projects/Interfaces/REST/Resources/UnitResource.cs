namespace IoBuilt.API.Projects.Interfaces.REST.Resources;

public record UnitResource(
    int Id,
    int ProjectId,
    string UnitNumber,
    int OwnerId
);
